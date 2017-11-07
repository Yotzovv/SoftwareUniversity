using GameStore.App.Infrastructure.Validation;
using GameStore.App.Infrastructure.Validation.Games;
using SimpleMvc.Framework.Attributes.Validation;
using System;

namespace GameStore.App.Models.Games
{
    public class GameAdminModel
    {
        [Required]
        [Title]
        public string Title { get; set; }

        [Required]
        [Description]
        public string Description { get; set; }

        [ThumbnailUrl]
        public string ThumbnailUrl { get; set; }

        [NumberRange(0, double.MaxValue)]
        public decimal Price { get; set; }

        [NumberRange(0, double.MaxValue)] 
        public double Size { get; set; }

        [Required]
        [Video]
        public string VideoId { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
