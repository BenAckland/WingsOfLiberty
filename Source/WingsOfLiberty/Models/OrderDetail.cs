using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AckBack3.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int GarmentId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual Order Order { get; set; }
        public virtual Garment Garment { get; set; }
    }
}