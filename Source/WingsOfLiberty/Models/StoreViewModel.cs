using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AckBack3.Models
{
    public class StoreViewModel
    {

        public IEnumerable<Garment> Shirts {get; set;}
        public IEnumerable<Size> Sizes { get; set; }
        public IEnumerable<int> SelectedSizes { get; set; }
    }
}