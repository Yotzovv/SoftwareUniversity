using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealer.A.Dtos
{
    [XmlType("car")]
    public class NovoDto
    {
        [XmlAttribute("travelled-distance")]
        public int Id { get; set; }

        [XmlAttribute("travelled-distance")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public double TravelledDistance { get; set; }
    }
}
