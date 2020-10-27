using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LocationLib
{
    public delegate void LocationDel();
    public class LocationTasks : ILocationOperations
    {
        string path = @"LocationLib\Inventory.txt";
        public event LocationDel checkedInventory;
        /// <summary>
        /// used to check inventory of location 
        /// seen by both customer and manager
        /// </summary>
        public async void CheckInventory()
        {
            Console.WriteLine("Pulling up location inventory");
            await Task.Run(new Action(GetInventory)); //create thread and returns to main when task is done
            Console.WriteLine("Location inventory is ready hit enter to see it");
            OnCheckedInventory(); //called to notify subscribers
        }
        /// <summary>
        /// checks event binding
        /// </summary>
        public void OnCheckedInventory()
        {
            if (checkedInventory != null)
            {
                CheckInventory();//raises event
            }
        }
        /// <summary>
        /// used to print out inventory at location
        /// </summary>
        public void GetInventory()
        {
            Console.WriteLine("Getting Inventory");
            System.Threading.Thread.Sleep(2000);
            string items = System.IO.File.ReadAllText(path);
            Console.WriteLine("Inventory Available: ");
            Console.WriteLine($"{items}");
        }
        /// <summary>
        /// section used to retrieve order history for location
        /// </summary>
        string path2 = @"LocationLib\OrderHistory.txt";
        public event LocationDel retrievedHistory;
        
        public async void RetrieveHistory()
        {
            Console.WriteLine("Beginning retrieval of location order history");
            await Task.Run(new Action(GetHistory));
            Console.WriteLine("Order history retrieved");
            OnRetrievedHistory();
        }
        /// <summary>
        /// checking event binding
        /// </summary>
        public void OnRetrievedHistory()
        {
            if(retrievedHistory != null)
            {
                retrievedHistory(); //raises event
            }
        }
        /// <summary>
        /// used to pull up and write out all history
        /// </summary>
        public void GetHistory()
        {
            Console.WriteLine("Pulling up order history");
            System.Threading.Thread.Sleep(2000);
            string history = System.IO.File.ReadAllText(path2);
            Console.WriteLine("Location history retrieved:");
            Console.WriteLine($"{history}");
        }
    }
}
