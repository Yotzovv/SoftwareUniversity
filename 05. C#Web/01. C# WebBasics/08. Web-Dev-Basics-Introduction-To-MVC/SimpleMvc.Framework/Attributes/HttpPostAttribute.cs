using SimpleMvc.Framework.Attributes.Methods;

namespace SimpleMvc.Framework.Attributes
{
    public class HttpPostAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string requestMethod)
        {
            if(requestMethod.ToUpper() == "POST")
            {
                return true;
            }

            return false;
        }
    }
}
