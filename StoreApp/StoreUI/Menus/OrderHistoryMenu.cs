//using ManagerLib;
//using StoreBL;
using LocationLib;
using OrderLib;
namespace StoreUI.Menus
{
    public class OrderHistoryMenu : IMenu
    {
       // StoreBL storeBL = new StoreBL();
        public void Start(){
            System.Console.WriteLine("Which order history would you like to see?");
            System.Console.WriteLine("[1] All order history /n [2] Order history by location /n [3] Order history by type /n [4] Order history by sport /n [5] Order history by athlete /n [6] exit");
            string orderHistory = System.Console.ReadLine();
            do{
                switch(orderHistory){
                    case "1":
                        System.Console.WriteLine("Here is all the order history for the store: ");
                        /// output all order history
                        break;
                    case "2":
                        Location location = new Location();
                        System.Console.WriteLine($"Redirecting you to order history menu for {location.LocationAddress}: ");
                        ///redirect to order history by location
                        ///import location from location menu
                        break;
                    case "3":
                        System.Console.WriteLine("Redirecting you to order history by type menu: ");
                        //redirecting to order history by type menu
                        break;
                    case "4":
                        System.Console.WriteLine("Redirecting you to order history by sport menu: ");
                        /// redirecting to order history by sport menu
                        break;
                    case "5":
                        System.Console.WriteLine("Redirecting you to order history by athlete: ");
                        /// redirecting to order history by athlete menu
                        break;
                    case "6":
                        System.Console.WriteLine("Redirecting you back to location menu");
                        /// redirecting to location menu
                        break;
                }
            }while (!orderHistory.Equals(6));
        }
        
    }
}