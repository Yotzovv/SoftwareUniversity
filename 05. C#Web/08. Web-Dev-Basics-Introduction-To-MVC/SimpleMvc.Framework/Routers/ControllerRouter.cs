using SimpleMvc.Framework.Attributes.Methods;
using SimpleMvc.Framework.Controllers;
using SimpleMvc.Framework.Interfaces;
using System;
using System.Collections.Generic;
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
        public IHttpResponse Handle(IHttpRequest request)
        {
            IDictionary<string, string> getParams = new Dictionary<string, string>();
            IDictionary<string, string> postParams = new Dictionary<string, string>();
            string requestMethod = string.Empty;
            string controllerName = string.Empty;
            string actionName = string.Empty;

            Controller controller = this.GetController(controllerName);

            if (controller != null)
            {
                controller.Request = request;
                controller.InitializeController();
            }

            MethodInfo method = this.GetMethod(controller, requestMethod, actionName);

            if (method == null)
            {
                return new NotFoundResponse();
            }

            IEnumerable<ParameterInfo> parameters = method.GetParameters();
            object[] methodParams = this.AddParameters(parameters, getParams, postParams);

            try
            {
                IHttpResponse response = this.GetResponse(method, controller, methodParams);
            }
            catch (Exception e)
            {
                return new InternalServerErrorResponse(e);
            }

            return null;
        }

        private IHttpResponse GetResponse(MethodInfo method, Controller controller, object[] methodParams)
        {
            object actionResult = method.Invoke(controller, methodParams);

            IHttpResponse response = null;

            if (actionResult is IViewable)
            {
                string content = ((IViewable)actionResult).Invoke();

                response = new ContentResponse(HttpStatusCode.Ok, content);
            }
            else if (actionResult is IRedirectable)
            {
                string redirectUrl = ((IRedirectable)actionResult).Invoke();

                response = new RedirectResponse(redirectUrl);
            }

            return response;
        }

        private object[] AddParameters(IEnumerable<ParameterInfo> parameters, IDictionary<string, string> getParams, IDictionary<string, string> postParams)
        {
            object[] methodParams = new object[parameters.Count()];

            int index = 0;

            foreach (ParameterInfo parameter in parameters)
            {
                if (parameter.ParameterType.IsPrimitive
                || parameter.ParameterType == typeof(string))
                {
                    methodParams[index] = this.ProcessPrimitiveParameter(parameter, getParams);
                    index++;
                }
                else
                {
                    methodParams[index] = this.ProcessComplexParameter(parameter, postParams);
                    index++;
                }
            }

            return methodParams;
        }

        private object ProcessComplexParameter(ParameterInfo parameter, IDictionary<string, string> postParams)
        {
            Type bindingModelType = parameter.ParameterType;

            object bindingModel = Activator.CreateInstance(bindingModelType);

            IEnumerable<PropertyInfo> properties = bindingModelType.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                property.SetValue(bindingModel,
                                  Convert.ChangeType(postParams[property.Name],
                                                     property.PropertyType));
            }

            return Convert.ChangeType(bindingModel, bindingModelType);
        }

        private object ProcessPrimitiveParameter(ParameterInfo parameter, IDictionary<string, string> getParams)
        {
            object value = getParams[parameter.Name];

            return Convert.ChangeType(value, parameter.ParameterType);
        }

        private MethodInfo GetMethod(Controller controller, string requestMethod, string actionName)
        {
            MethodInfo method = null;

            foreach (MethodInfo methodInfo in this.GetSuitableMethods(controller, actionName))
            {
                IEnumerable<Attribute> attributes =
                    methodInfo.GetCustomAttributes<HttpMethodAttribute>();

                if (!attributes.Any() && requestMethod == "Get")
                {
                    return methodInfo;
                }

                foreach (HttpMethodAttribute attribute in attributes)
                {
                    if (attribute.IsValid(requestMethod))
                    {
                        return methodInfo;
                    }
                }
            }

            return method;
        }

        private IEnumerable<MethodInfo> GetSuitableMethods(Controller controller, string actionName)
        {
            if (controller == null)
            {
                return new MethodInfo[0];
            }

            return controller.GetType()
                             .GetMethods()
                             .Where(m => m.Name == actionName);
        }

        private Controller GetController(string controllerName)
        {
            var controllerFullQualifiedName = string.Format("{0}.{1}.{2}, {0}",
                                                            MvcContext.Get.AssemblyName,
                                                            MvcContext.Get.ControllersFolder,
                                                            controllerName);

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
