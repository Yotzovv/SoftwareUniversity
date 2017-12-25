using System;

namespace Market.Data.Models
{
    public class Image
    {
        public int Id { get; set; }

        public byte[] ImageBytes { get; set; }

        public int ProductId { get; set; }

        public Post Product { get; set; }

        public bool IsProductProfilePicture { get; set; } = false;
    }
}
