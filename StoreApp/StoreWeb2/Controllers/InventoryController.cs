using Microsoft.AspNetCore.Mvc;
using StoreDB;
using StoreDB.Entities;
using StoreDB.Models;
using System.Collections.Generic;
using db = StoreDB.Models;

namespace StoreWeb2.Controllers
{
     public class InventoryController : Controller
     {
        private IStoreRepo storeRepo;
        db.CustomerModels customer = new db.CustomerModels();
        db.InventoryModel inventoryModel = new db.InventoryModel();
        db.LocationModel locationModel = new db.LocationModel();
       /* public IActionResult GetAllProductsAtLocation(int id)
         {
            List<InventoryModel> inventory = storeRepo.ViewAllProductsAtLocation(id);
             return View(locationInventory);
             ///want to send this to matching location may need to have 1 for each
         } */
     } 
}
