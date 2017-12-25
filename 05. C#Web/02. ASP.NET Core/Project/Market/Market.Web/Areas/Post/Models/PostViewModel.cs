using Market.Data.Models;
using Market.Data.Models.Enums;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Market.Web.Areas.Product.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public Categories Category { get; set; }

        public IEnumerable<Image> Images { get; set; } = new List<Image>();

        public IEnumerable<IFormFile> FormUploadedImages { get; set; }
    }
}
