using SimpleMvc.Framework.Attributes.Validation;

namespace GameStore.App.Infrastructure.Validation.Games
{
    public class VideoAttribute : PropertyValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var videoId = value as string;

            if(videoId == null)
            {
                return true;
            }

            return videoId.Length == 11;
        }
    }
}
