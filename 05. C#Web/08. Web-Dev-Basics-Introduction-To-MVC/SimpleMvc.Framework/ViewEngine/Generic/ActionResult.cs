using SimpleMvc.Framework.Interfaces.Generic;
using System;

namespace SimpleMvc.Framework.ViewEngine.Generic
{
    public class ActionResult<T> : IActionResult<T>
    {
        public ActionResult(string viewFullQualifiedName, T model)
        {
            this.Action = (IRenderable<T>)Activator.CreateInstance(Type.GetType(viewFullQualifiedName));

            // TODO: set the model of action
            this.Action.Model = model;
        }

        public IRenderable<T> Action { get; set; }

        public string Invoke()
        {
            return this.Action.Render();
        }
    }
}
