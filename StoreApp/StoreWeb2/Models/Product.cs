using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StoreWeb2.Models
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        [DisplayName("Product ID")]
        public int ID { get; set; }
        [Required]
        [DisplayName("Athlete")]
        [DataType(DataType.Text)]
        public string Athlete { get; set; }
        [Required]
        [DisplayName("Item")]
        [DataType(DataType.Text)]
        public string Item { get; set; }
        [Required]
        [DisplayName("Sport")]
        [DataType(DataType.Text)]
        public string Sport { get; set; }
        [Required]
        [DisplayName("Price")]
        public decimal Price { get; set; }
    }
}
