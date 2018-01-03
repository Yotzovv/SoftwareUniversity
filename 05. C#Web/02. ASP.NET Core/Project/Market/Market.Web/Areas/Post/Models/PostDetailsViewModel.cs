using Market.Common.Mapping;
using Market.Data.Models;
using System.Collections.Generic;
using AutoMapper;
using Market.Services;
using System.Threading.Tasks;
using Market.Data.Models.Enums;
using System;

namespace Market.Web.Areas.Product.Models
{
    public class PostDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public Categories Category { get; set; }
        
        public int ViewsCount { get; set; }

        public DateTime SubmissionDate { get; set; }

        public List<Image> Images { get; set; }

        public ApplicationUser Owner { get; set; }

        public string SendedMessage { get; set; }
    }
}
