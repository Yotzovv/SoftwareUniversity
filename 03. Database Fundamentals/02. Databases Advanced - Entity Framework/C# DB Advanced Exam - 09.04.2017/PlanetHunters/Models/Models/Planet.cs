using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Planet
    {
        private decimal mass;

        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public decimal Mass
        {
            get
            {
                return mass;
            }
            set
            {
                if(value < 0)
                {
                    Console.WriteLine("Error: Mass must be greater than zero.");
                }
                else
                {
                    mass = value;
                }
            }
        }

        public int StarSystemId { get; set; }

        [Required]
        public virtual StarSystem StarSystem { get; set; }


    }
}
