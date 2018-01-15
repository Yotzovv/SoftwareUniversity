using System;

namespace Market.Data.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string RecipientId { get; set; }

        public ApplicationUser Recipient { get; set; }

        public string SenderId { get; set; }

        public ApplicationUser Sender { get; set; }

        public int ProductId { get; set; }

        public Post Product { get; set; }

        public string RecipientDeliveryOfficeAddress { get; set; }

        public DateTime OrderedDate { get; set; }

        public bool WillSend { get; set; }

        public bool IsRecieved { get; set; }
    }
}
