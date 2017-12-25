using System;

namespace Market.Data.Models
{
    public class Message
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime TextSentDate { get; set; }


        public string RecieverId { get; set; }

        public ApplicationUser Reciever { get; set; }


        public string SenderId { get; set; }

        public ApplicationUser Sender { get; set; }

    }
}
