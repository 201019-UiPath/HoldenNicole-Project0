using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreWeb2.Models;

namespace StoreWeb.Data
{
    public class EmpDBContext : DbContext
    {
        public EmpDBContext (DbContextOptions<EmpDBContext> options)
            : base(options)
        {
        }

        public DbSet<StoreWeb2.Models.Cart> Cart { get; set; }

        public DbSet<StoreWeb2.Models.CartItem> CartItem { get; set; }

        public DbSet<StoreWeb2.Models.Customer> Customer { get; set; }

        public DbSet<StoreWeb2.Models.Inventory> Inventory { get; set; }

        public DbSet<StoreWeb2.Models.LineItem> LineItem { get; set; }

        public DbSet<StoreWeb2.Models.Location> Location { get; set; }

        public DbSet<StoreWeb2.Models.Manager> Manager { get; set; }

        public DbSet<StoreWeb2.Models.Order> Order { get; set; }

        public DbSet<StoreWeb2.Models.Product> Product { get; set; }
    }
}
