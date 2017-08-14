using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photographers.Models
{
    public class Tag
    {
        public Tag()
        {
            this.Albums = new List<Album>();
        }

        public int Id { get; set; }

        public string Label { get; set; }


        public virtual List<Album> Albums { get; set; }

    }
}
