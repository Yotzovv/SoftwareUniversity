using SimpleMvc.Framework.Attributes.Methods;

namespace SimpleMvc.Framework.Attributes
{
    public class HttpGetAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string requestMethod)
        {
            if(requestMethod.ToUpper() == "GET")
            {
                return true;
            }

            return false;
        }
    }
}
