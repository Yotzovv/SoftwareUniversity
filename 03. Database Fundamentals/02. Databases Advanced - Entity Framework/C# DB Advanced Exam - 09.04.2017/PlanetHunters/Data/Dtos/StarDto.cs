using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos
{
    public class StarDto
    {
        public string Name { get; set; }
        public int Temperature { get; set; }
        public int StarSystemId { get; set; }
        public string StarSystem { get; set; }
    }
}
