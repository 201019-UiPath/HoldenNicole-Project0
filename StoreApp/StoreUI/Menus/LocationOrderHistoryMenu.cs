using StoreBL;

namespace StoreUI.Menus
{
    public class LocationOrderHistoryMenu : IMenu
    {
        private StoreBLL storeBL = new StoreBLL();
        public void Start(){
            LocationLib.Location locationID = new LocationLib.Location();
            
            System.Console.WriteLine($"How would you like the order history for {locationID.LocationName} sorted?");
            System.Console.WriteLine("[1] Date most recent-oldest /n [2] Date oldest-most recent /n [3] Price high-low /n [4] Price low-high /n [5] Return to customer menu /n [6] exit");
            string sortedHistory = System.Console.ReadLine();
            do{
                switch (sortedHistory){
                    case "1":
                        System.Console.WriteLine("Here is the location order history sorted by most recent first: ");
                        /// output sorted order history most recent first
                        break;
                    case "2":
                        System.Console.WriteLine("Here is the location order history with oldest orders first: ");
                        /// output sorted order history oldest first
                        break;
                    case "3":
                        System.Console.WriteLine("Here is the location order history sorted by highest price first: ");
                        /// output sorted order history most expensive first
                        break;
                    case "4":
                        System.Console.WriteLine("Here is the location order history with cheapest items first: ");
                        /// output sorted order history cheapest items first
                        break;
                    case "5":
                        System.Console.WriteLine("Redirecting you back to the order history menu: ");
                        /// <summary>
                        /// return manager to order history menu
                        /// </summary>
                        /// <returns></returns>
                        break;
                }
            } while(!sortedHistory.Equals(6));
        }
    }
}