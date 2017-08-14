using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDB2
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CreditCardNumber { get; set; }
        public int Age { get; set; }
        public List<Sale> SalesForCustomer { get; set; }
    }
}
