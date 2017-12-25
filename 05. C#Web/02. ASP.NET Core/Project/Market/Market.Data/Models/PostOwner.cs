namespace Market.Data.Models
{
    public class PostOwner
    {
        public string OwnerId { get; set; }

        public ApplicationUser Owner { get; set; }

        public int PostId { get; set; }

        public Post Post { get; set; }
    }
}
