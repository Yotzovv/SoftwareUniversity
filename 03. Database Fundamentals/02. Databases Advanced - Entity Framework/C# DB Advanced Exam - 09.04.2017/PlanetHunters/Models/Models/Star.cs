using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Star
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [Range(2400, int.MaxValue)]
        public int Temperature { get; set; }

        public int StarSystemId { get; set; }

        [Required]
        public StarSystem StarSystem { get; set; }

    }
}
