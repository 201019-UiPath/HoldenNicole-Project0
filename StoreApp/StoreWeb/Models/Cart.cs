using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StoreWeb2.Models
{
    public class Cart
    {
        [HiddenInput(DisplayValue = false)]
        [DisplayName("Cart ID")]
        public int ID { get; set; }
        [Required]
        [DisplayName("Customer ID")]
        public int CustomerID { get; set; }
        [Required]
        [DisplayName("Location ID")]
        public int LocationID { get; set; }
        [DisplayName("Cart Items")]
        public List<CartItem> CartItem { get; set; }
    }
 /*   public class EmpDBContext: DBContext
    {
        public DbSet<Cart> Cart { get; set; }
    } */
}