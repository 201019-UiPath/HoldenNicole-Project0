using System;
using System.Threading.Tasks;
using System.Text;
using System.Collections.Generic;

namespace LocationLib
{
    public delegate void LocationDel();
    public class LocationTasks : ILocationOperations
    {
        string path = @"LocationLib\LocationInventory.txt";
        public event LocationDel managedInventory;

        ///section to check inventory
        public void GetInventory(){
            System.Console.WriteLine("Getting all items in inventory");
            System.Threading.Thread.Sleep(2000);
            string items = System.IO.File.ReadAllText(path);
            System.Console.WriteLine("Items in store inventory");
            System.Console.WriteLine($"{items}");
        }

        /// allows manager to see store inventory
        public async void AddInventory(){
            System.Console.WriteLine("Opened Store Inventory");
            await Task.Run(new Action(GetInventory)); //retrieves inventory list
            System.Console.WriteLine("Adding to inventory");
            OnAddInventory();
        }
        public void OnAddInventory(){
            if(managedInventory != null){
                managedInventory();
            }
        }

        string path2 = @"LocationLib\LocationOrderHistory.txt";
        public event LocationDel OrderHistory;
        ///retrieves location order history which can be further sorted from menus

        public async void GetHistory(){
            System.Console.WriteLine("Retrieving location order history");
            await.Task.Run(new Action(LocationOrderHistory));
            System.Console.WriteLine("Order history acquired");
            OrderHistory();
        }

        public void LocationOrderHistory(){
            System.Console.WriteLine("Compiling order history");
            System.Threading.Thread.Sleep(2000);
            string orderHistory = System.IO.File.ReadAllText(path2);
            System.Console.WriteLine("Order history obtained");
            System.Console.WriteLine($"{orderHistory}");
        }
    }
}