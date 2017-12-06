﻿using BookShop.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Api.Model.Books
{
    public class CreateBookRequestModel
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public decimal Price { get; set; }
        
        public int Copies { get; set; }

        public int? Edition { get; set; }

        public int? AgeRestriction { get; set; }
        
        public DateTime ReleaseDate { get; set; }

        public int AuthorId { get; set; }

        public string Categories { get; set; } 
    }
}
