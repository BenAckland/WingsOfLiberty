using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AckBack3.Models
{
    public class WoLDbContext : DbContext
    {
        public DbSet<Garment> Garments { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}