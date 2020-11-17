using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace StoreWeb2.Models
{
    public class Manager
    {
        [HiddenInput(DisplayValue = false)]
        [DisplayName("Manager ID")]
        public int ID { get; set; }
        [Required]
        [DisplayName("Username")]
        [DataType(DataType.Text)]
        public string Username { get; set; }
        [Required(ErrorMessage = "a valid email is required")]
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "invalid email address")]
        public string Email { get; set; }
        [DisplayName("Locations")]
        public List<Location> Location { get; set; }
    }
    public class EmpDBContextM : DbContext
    {
        public DbSet<Manager> Managers { get; set; }
    }
}