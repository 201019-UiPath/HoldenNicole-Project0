using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreDB;
using StoreWeb2.Models;
using db = StoreDB.Models;
using StoreDB.Models;

namespace StoreWeb2.Controllers
{
    public class ManagerController : Controller
    {
        private IStoreRepo storeRepo;
        db.ManagerModel manager = new db.ManagerModel();
        public void ManagersController(IStoreRepo repo)
        {
            storeRepo = repo;
        }
        public IActionResult SignInAsManager(string manager)
        {
            db.ManagerModel managers = storeRepo.GetManagerByName(manager);
            return View(managers);
        }
        public IActionResult PickManagerLocation(int id)
        {
            db.LocationModel location = storeRepo.GetLocationByManager(id);
            return View(location);
        }
        public IActionResult GetOrdersByLocation(int id)
        {
            List<OrderModel> orders = storeRepo.GetAllOrdersByLocationIDDateAscending(id);
            return View(orders);
        }
       /* public IActionResult AddProductToLocation(int locationid, int productid, int quantity)
        {
            
            return View(locationInventory);
            ///want to send this to matching location may need to have 1 for each
        }
        public IActionResult RemoveProductFromLocation(Inventory inventory)
        {
            
            return View(locationInventory);
            ///want to send this to matching location may need to have 1 for each
        } */
    } 
}
