using System.ComponentModel.DataAnnotations;

namespace CarDealer.Domain
{
    public class Sale
    {
        public int Id { get; set; }
        
        [Range(0, 100)]
        public double Discount { get; set; }

        public int CatId { get; set; }
        
        public virtual Car Car { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
