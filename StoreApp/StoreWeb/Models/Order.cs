using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace StoreWeb2.Models
{
    public class Order
    {
        [HiddenInput(DisplayValue = false)]
        [DisplayName("Order ID")]
        public int ID { get; set; }
        [Required]
        [DisplayName("Customer ID")]
        public int CustomerID { get; set; }
        [Required]
        [DisplayName("Location ID")]
        public int LocationID { get; set; }
        [Required]
        [DisplayName("Order Date")]
        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }
        [Required]
        [DisplayName("Price")]
        public decimal Price { get; set; }
        [DisplayName("Line Items")]
        public List<LineItem> LineItem { get; set; }
    }
    public class EmpDBContextO : DbContext
    {
        public DbSet<Order> Orders { get; set; }
    }
}