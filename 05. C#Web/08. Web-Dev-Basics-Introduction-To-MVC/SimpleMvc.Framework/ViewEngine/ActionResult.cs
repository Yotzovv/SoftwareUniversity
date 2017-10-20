using SimpleMvc.Framework.Interfaces;
using System;

namespace SimpleMvc.Framework.ViewEngine
{
    public class ActionResult : IActionResult
    {
        public ActionResult(string viewFulllQualifiedName)
        {
            this.Action = (IRenderable)Activator.CreateInstance(Type.GetType(viewFulllQualifiedName));
        }

        public IRenderable Action { get; set; }

        public string Invoke()
        {
            return this.Action.Render();
        }
    }
}
