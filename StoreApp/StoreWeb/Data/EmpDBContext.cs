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

        public DbSet<Cart> Cart { get; set; }

        public DbSet<CartItem> CartItem { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Inventory> Inventory { get; set; }

        public DbSet<LineItem> LineItem { get; set; }

        public DbSet<Location> Location { get; set; }

        public DbSet<Manager> Manager { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<Product> Product { get; set; }
    }
}
