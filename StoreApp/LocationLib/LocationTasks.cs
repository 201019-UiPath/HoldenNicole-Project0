using StoreUI;
using StoreDB.Entities;

namespace LocationLib
{
    public delegate void LocationDel();
    public class LocationTasks : ILocationOperations
    {
        public DBRepo dbRepo;
        public event LocationDel ManagedInventory;

        ///section to check inventory
        public void GetInventory(int id)
        {
            System.Console.WriteLine("Getting all items in inventory");
            System.Console.WriteLine("Items in store inventory");
            dbRepo.ViewAllProductsAtLocation(id);
            ///return list "items"
        }
        /// allows manager to see add to inventory
        public void AddProductToLocation(int locationid, int productid, int quantity)
        {
            System.Console.WriteLine("Opened Store Inventory");
            dbRepo.AddProductToLocation(locationid, productid, quantity); //manager can add to location inventory
            System.Console.WriteLine("Adding to inventory");
            OnAddInventory();
        }
        public void OnAddInventory()
        {
            if (ManagedInventory != null)
            {
                ManagedInventory();
            }
        }

        public event LocationDel OrderHistory;
        ///retrieves location order history which can be further sorted from menus

        public void GetHistory(int id)
        {
            System.Console.WriteLine("Retrieving location order history");
            System.Console.WriteLine("Order history acquired");
           // dbRepo.GetAllOrdersByLocationIDDateAscending(id); //return OrderHistory
            OrderHistory();
        }
    }
}