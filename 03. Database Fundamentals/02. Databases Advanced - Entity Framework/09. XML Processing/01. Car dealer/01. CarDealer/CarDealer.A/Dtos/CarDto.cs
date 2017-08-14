using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealer.A.Dtos
{
    [XmlType("car")]
    public class CarDto
    {
        public CarDto()
        {
            this.Parts = new List<PartDto>();
        }
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public double TravelledDistance { get; set; }

        public virtual List<PartDto> Parts { get; set; }
    }
}
