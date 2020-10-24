//using ManagerLib;
//using StoreBL;
using LocationLib;
using System.Text.RegularExpressions;
using System.Collections.Generic;
namespace StoreUI.Menus
{
    public class LocationMenu : IMenu
    {
        //StoreBL storeBL = new StoreBL();
        public void Start(){
            System.Console.WriteLine("Which location are you the manager for?");
            System.Console.WriteLine("[1] Location 1 /n [2] Location 2 /n [3] Location 3 ");
            string locationID = System.Console.ReadLine();

            System.Console.WriteLine($"What would you like to do for {locationID.LocationName}");
            System.Console.WriteLine("[1] View order history for this location /n [2] View location inventory /n [3] exit");
            string managerInput = System.Console.ReadLine();
            do{
                switch(managerInput){
                    case "1":
                        System.Console.WriteLine("Redirecting you to the location order history menu");
                        /// <summary>
                        /// send manager to location order history menu
                        /// </summary>
                        break;
                    case "2":
                        System.Console.WriteLine("Redirecting you to location inventory menu");
                        /// <summary>
                        /// send manager to location order history menu with locationID
                        /// </summary>
                        break;
                    default:
                        System.Console.WriteLine("Redirecting you back to sign in menu");
                        /// <summary>
                        /// send user back to sign in/ sign up menu
                        /// </summary>
                        break;
                }
            } while (!managerInput.Equals(3));
        }
        
    }
}