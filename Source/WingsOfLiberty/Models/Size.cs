using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AckBack3.Models
{
    public class Size
    {
        public int SizeID { get; set; }
        public string Name { get; set; }
        public string Dimensions { get; set; }
        public virtual ICollection<Garment> Garments { get; set; }
    }
}