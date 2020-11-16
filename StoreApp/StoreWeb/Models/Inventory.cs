using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace StoreWeb2.Models
{
    public class Inventory
    {
        [HiddenInput(DisplayValue = false)]
        [DisplayName("Inventory ID")]
        public int ID { get; set; }
        [Required]
        [DisplayName("Location ID")]
        public int LocationID { get; set; }
        [Required]
        [DisplayName("Product ID")]
        public int ProductID { get; set; }
        [Required]
        [DisplayName("Quantity")]
        public int Quantity { get; set; }
    }
    public class EmpDBContextI : DbContext
    {
        public DbSet<Inventory> Inventories { get; set; }
    }
}