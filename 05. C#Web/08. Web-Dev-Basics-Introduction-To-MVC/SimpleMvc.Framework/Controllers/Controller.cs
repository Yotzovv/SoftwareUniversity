using SimpleMvc.Framework.ActionResults;
using SimpleMvc.Framework.Attributes.Property;
using SimpleMvc.Framework.Interfaces;
using SimpleMvc.Framework.Models;
using SimpleMvc.Framework.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using WebServer.Http;
using WebServer.Http.Contracts;

namespace SimpleMvc.Framework.Controllers
{
    public class Controller
    {
        public Controller()
        {
            this.Model = new ViewModel();
            this.User = new Authentication();
        }

        protected ViewModel Model { get; }

        protected internal IHttpRequest Request { get; internal set; }

        protected internal Authentication User { get; private set; }


        private void InitializeViewModelData()
        {
            this.Model["displayTips"] = this.User.IsAuthenticated ? "block" : "none";
        }

        protected internal void InitializeController()
        {
            var user = this.Request
                           .Session
                           .Get<string>(SessionStore.CurrentUserKey);

            if (user != null)
            {
                this.User = new Authentication(user);
            }
        }

        protected void SignIn(string name)
        {
            this.Request.Session.Add(SessionStore.CurrentUserKey, name);
        }

        protected void SignOut()
        {
            this.Request.Session.Clear();
        }

        protected IViewable View([CallerMemberName] string caller = "")
        {
            this.InitializeViewModelData();

            string controllerName = this.GetType()
                                        .Name
                                        .Replace(MvcContext.Get.ControllersSuffix, string.Empty);

            string fullQualifiedNAme = string.Format(
                                       "{0}.{1}.{2}.{3}, {0}",
                                        MvcContext.Get.AssemblyName,
                                        MvcContext.Get.ViewsFolder,
                                        controllerName,
                                        caller);

            IRenderable view = new View.View(fullQualifiedNAme, this.Model.Data);

            return new ViewResult(view);
        }

        protected bool IsValidModel(object bindingModel)
        {
            foreach (var prop in bindingModel.GetType().GetProperties())
            {
                IEnumerable<Attribute> attributes = prop.GetCustomAttributes()
                                                        .Where(a => a is PropertyAttribute);

                if (!attributes.Any())
                {
                    continue;
                }

                foreach (PropertyAttribute attribute in attributes)
                {
                    if (!attribute.IsValid(prop.GetValue(bindingModel)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
