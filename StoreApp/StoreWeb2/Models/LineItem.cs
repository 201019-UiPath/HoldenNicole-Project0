using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StoreWeb2.Models
{
    public class LineItem
    {
        [HiddenInput(DisplayValue = false)]
        [DisplayName("Cart Item ID")]
        public int ID { get; set; }
        [Required]
        [DisplayName("Order ID")]
        public int OrderID { get; set; }
        [Required]
        [DisplayName("Product ID")]
        public int ProductID { get; set; }
        [Required]
        [DisplayName("Quantity Available")]
        public int Quantity { get; set; }
    }
}
