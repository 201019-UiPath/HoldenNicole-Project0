using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace StoreWeb2.Models
{
    public class Customer
    {
        [HiddenInput(DisplayValue = false)]
        [DisplayName("Customer ID")]
        public int ID { get; set; }
        [Required]
        [DisplayName("Username")]
        [DataType(DataType.Text)]
        public string Username { get; set; }
        [Required(ErrorMessage = "a valid email is required")]
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "invalid email address")]
        public string Email { get; set; }
        [DisplayName("Carts")]
        public List<Cart> Carts { get; set; }
        [DisplayName("Orders")]
        public List<Order> Orders { get; set; }
    }
    public class EmpDBContextCu : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
    }
}