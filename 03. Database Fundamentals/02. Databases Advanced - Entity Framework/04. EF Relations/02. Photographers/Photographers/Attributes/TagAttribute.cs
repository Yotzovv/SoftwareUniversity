//using System.ComponentModel.DataAnnotations;

//namespace Photographers.Attributes
//{
//    public class TagAttribute : ValidationAttribute
//    {
//        public override bool isValid(object tag)
//        {
//            string tagValue = (string)tag;

//            if(!tagValue.StartsWith("#"))
//            {
//                return false;
//            }

//            if(tagValue.Contains(" ") || tagValue.Contains("\t"))
//            {
//                return false;
//            }

//            if(tagValue.Length > 20)
//            {
//                return false;
//            }
//            return true;
//        }
//    }
//}
