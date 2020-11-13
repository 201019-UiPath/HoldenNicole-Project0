using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreDB;
using StoreWeb2.Models;
using db=StoreDB.Models;

namespace StoreWeb2.Controllers
{
   /* public class CustomerController : Controller
    {
        private IStoreRepo storeRepo;
        db.CustomerModels customer = new db.CustomerModels();
        public void CustomersController(IStoreRepo repo)
        {
            storeRepo = repo;
        }
        public IActionResult AddCustomer(CustomerController newCustomer)
        {
            if (ModelState.IsValid)
            {
                customer.ID = newCustomer.ID;
                customer.Username = newCustomer.Username;
                customer.email = newCustomer.Email;
                storeRepo.AddCustomer(newCustomer);
                return RedirectToAction("");
            }
            else
            {
                return View(signIn);
            }
        }
        public IActionResult SignInAsCustomer(CustomerController returningCustomer)
        {
            
            return View(customerHome);
        }
        public IActionResult GetOrdersByCustomer(Order order)
        {

            return View(customerHistory);
        }
        public IActionResult AddItemToCartFromCart(CartItem cartItem)
        {

            return View(cart);
        }
        public IActionResult RemoveItemFromCartFromCart(CartItem cartItem)
        {

            return View(cart);
        }
        public IActionResult AddItemToCartFromInventory(CartItem cartItem)
        {

            return View(locationInventory);
            ///want to send this to matching location may need to have 1 for each
        }
        public IActionResult RemoveItemFromCartFromInventory(CartItem cartItem)
        {

            return View(locationInventory);
            ///want to send this to matching location may need to have 1 for each
        }
        public IActionResult PickShoppingLocation(Location location)
        {
            ///want this to send to matching location so may need 1 for each location
            return View(locationInventory);
        }
    } */
}
