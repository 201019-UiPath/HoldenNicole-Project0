using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StoreWeb2.Models
{
    public class Location
    {
        [HiddenInput(DisplayValue = false)]
        [DisplayName("Location ID")]
        public int ID { get; set; }
        [Required]
        [DisplayName("Manager ID")]
        public int ManagerID { get; set; }
        [Required]
        [DisplayName("Location Name")]
        public int LocationName { get; set; }
        [DisplayName("Cart")]
        public List<Cart> Carts { get; set; }
        [DisplayName("Inventory")]
        public List<Inventory> Inventory { get; set; }
        [DisplayName("Order")]
        public List<Order> Order { get; set; }
    }
}