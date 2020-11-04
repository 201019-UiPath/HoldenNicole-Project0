using StoreUI;
using StoreUI.Entities;

namespace LocationLib
{
    public delegate void LocationDel();
    public class LocationTasks : ILocationOperations
    {
        public DBRepo dbRepo;
        public event LocationDel managedInventory;

        ///section to check inventory
        public void GetInventory(int id)
        {
            System.Console.WriteLine("Getting all items in inventory");
            System.Console.WriteLine("Items in store inventory");
            dbRepo.ViewAllProductsAtLocationGroupBySport(id);
            ///return list "items"
        }
        /// allows manager to see add to inventory
        public void AddInventory(Products product)
        {
            System.Console.WriteLine("Opened Store Inventory");
            dbRepo.AddProductToLocationAsync(product); //manager can add to location inventory
            System.Console.WriteLine("Adding to inventory");
            OnAddInventory();
        }
        public void OnAddInventory()
        {
            if (managedInventory != null)
            {
                managedInventory();
            }
        }

        public event LocationDel OrderHistory;
        ///retrieves location order history which can be further sorted from menus

        public void GetHistory(int id)
        {
            System.Console.WriteLine("Retrieving location order history");
            System.Console.WriteLine("Order history acquired");
            dbRepo.GetAllOrdersByLocationIDDateAscending(id); //return OrderHistory
            OrderHistory();
        }
    }
}