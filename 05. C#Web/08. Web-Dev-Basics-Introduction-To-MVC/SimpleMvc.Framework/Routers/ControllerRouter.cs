using SimpleMvc.Framework.Attributes.Methods;
using SimpleMvc.Framework.Controllers;
using SimpleMvc.Framework.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using WebServer.Contracts;
using WebServer.Enums;
using WebServer.Http.Contracts;
using WebServer.Http.Response;

namespace SimpleMvc.Framework.Routers
{
    public class ControllerRouter : IHandleable
    {
        private Dictionary<string, string> getParams;
        private IDictionary<string, string> postParams;
        private string requestMethod;
        private string controllerName;
        private string actionName;
        private object[] methodParams;

        public ControllerRouter()
        {
            this.getParams = new Dictionary<string, string>();
            this.postParams = new Dictionary<string, string>();
        }

        public IHttpResponse Handle(IHttpRequest request)
        {
            // 1. Parse input from request
            // -  Retrieve Get parameters from request's URL if there are any
            if (request.Method.ToString() == "Get")
            {
                var getParameters = request.Url.Split('&');

                foreach (var get in getParameters)
                {
                    var nameValue = get.Split(new[] { '/', '?' }, StringSplitOptions.RemoveEmptyEntries);

                    if (nameValue.Length == 1)
                    {
                        return null;
                    }
                    else if(nameValue.Length == 3)
                    {
                        var id = nameValue[2].Split('=');

                        getParams[id[0]] = (id[1]);
                    }

                    getParams[nameValue[0]] = nameValue[1];
                }
            }

            // -  Retrieve POST parameters from request's Content if there are any
            if (request.Method.ToString() == "Post")
            {
                var postParameters = request.FormData;

                foreach (var post in postParameters)
                {
                    var nameValue = post;

                    postParams[nameValue.Key] = nameValue.Value;

                }
            }

            // -  Retrieve the request method
            this.requestMethod = request.Method.ToString();

            // -  Retrieve the controller name
            var controllerNameAndAction = request.Url.Split(new[] { '/', '?' }, StringSplitOptions.RemoveEmptyEntries);

            this.controllerName = new CultureInfo("en-US", false).TextInfo
                                                                 .ToTitleCase(controllerNameAndAction[0])
                                                                 + "Controller";
            // -  Retrieve the action name
            this.actionName = new CultureInfo("en-US", false).TextInfo
                                                             .ToTitleCase(controllerNameAndAction[1]);

            // -  Retrieve the method
            MethodInfo method = this.GetMethod();

            if (method == null)
            {
                return new NotFoundResponse();
            }

            IEnumerable<ParameterInfo> parameters = method.GetParameters();
            this.methodParams = new object[parameters.Count()];

            int index = 0;

            foreach (ParameterInfo param in parameters)
            {
                if (param.ParameterType.IsPrimitive
                || param.ParameterType == typeof(string))
                {
                    object value = this.getParams[param.Name];
                    this.methodParams[index] = Convert.ChangeType(value, param.ParameterType);

                    index++;
                }
                else
                {
                    Type bindingModelType = param.ParameterType;
                    object bindingModel = Activator.CreateInstance(bindingModelType);

                    IEnumerable<PropertyInfo> properties = bindingModelType.GetProperties();

                    foreach (PropertyInfo property in properties)
                    {
                        property.SetValue(bindingModel,
                                          Convert.ChangeType
                                              (
                                                 postParams[property.Name],
                                                 property.PropertyType
                                              )
                                          );
                    }

                    this.methodParams[index] = Convert.ChangeType(bindingModel, bindingModelType);

                    index++;
                }

            }

            IInvocable actionResult = (IInvocable)this.GetMethod()
                                                      .Invoke(this.GetController(),
                                                              this.methodParams);
            string content = actionResult.Invoke();
            IHttpResponse response = new ContentResponse(HttpStatusCode.Ok, content);

            return response;
        }

        private MethodInfo GetMethod()
        {
            MethodInfo method = null;

            foreach (MethodInfo methodInfo in this.GetSuitableMethods())
            {
                IEnumerable<Attribute> attributes =
                    methodInfo.GetCustomAttributes<HttpMethodAttribute>();

                if (!attributes.Any() && this.requestMethod == "Get")
                {
                    return methodInfo;
                }

                foreach (HttpMethodAttribute attribute in attributes)
                {
                    if (attribute.IsValid(this.requestMethod))
                    {
                        return methodInfo;
                    }
                }
            }

            return method;
        }

        private IEnumerable<MethodInfo> GetSuitableMethods()
        {
            var controller = this.GetController();

            if (controller == null)
            {
                return new MethodInfo[0];
            }

            return controller.GetType()
                             .GetMethods()
                             .Where(m => m.Name == this.actionName);
        }

        private object GetController()
        {
            var controllerFullQualifiedName = string.Format("{0}.{1}.{2}, {0}",
                                                            MvcContext.Get.AssemblyName,
                                                            MvcContext.Get.ControllersFolder,
                                                            this.controllerName);

            Type type = Type.GetType(controllerFullQualifiedName);

            if (type == null)
            {
                return null;
            }

            var controller = (Controller)Activator.CreateInstance(type);

            return controller;
        }
    }
}
