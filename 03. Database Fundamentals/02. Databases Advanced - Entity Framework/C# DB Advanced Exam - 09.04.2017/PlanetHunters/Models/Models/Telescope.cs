using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Telescope
    {
        private float? mirrorDiameter;

        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Location { get; set; }

        public float? MirrorDiameter
        {
            get
            {
                return this.mirrorDiameter;
            }
            set
            {
                if (value > 0)
                {
                    this.mirrorDiameter = value;
                }
                else
                {
                    mirrorDiameter = null;
                }
            }
        }
    }
}
