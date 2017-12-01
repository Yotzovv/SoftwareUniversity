using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace LearningSystem.Web.Infrastructure.Extensions
{
    public static class FormFileExtensions
    {
        public static async Task<byte[]> ToByteArrayAsync(this IFormFile formFile)
        {
            using (var memmoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memmoryStream);
                return memmoryStream.ToArray();
            }
        }
    }
}
