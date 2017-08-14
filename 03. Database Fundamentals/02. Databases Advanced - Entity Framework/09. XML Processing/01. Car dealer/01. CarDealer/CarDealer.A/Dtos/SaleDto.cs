using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealer.A.Dtos
{
    public class SaleDto
    {
       [XmlAttribute("discount")]
        public int Discount { get; set; }

        public int Car_Id { get; set; }

        public int Customer_Id { get; set; }

        public virtual CarDto Car { get; set; }

        public virtual CustomerDto Customer { get; set; }
    }
}
