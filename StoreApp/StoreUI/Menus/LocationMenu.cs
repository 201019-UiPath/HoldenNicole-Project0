using System;
using LocationLib;

namespace StoreUI.Menus
{
    class LocationMenu : IMenu
    {
        public void Start()
        {
            Location location = new Location();
            Console.WriteLine("Please pick from this list of stores to look for the inventory for that store:");
            Console.WriteLine("[1] World of Bats /n [2] World of Games /n [3] World of Jerseys /n [4] World of Sticks /n [5] exit store");
            string locationID = Console.ReadLine();
            do
            {
                switch (locationID)
                {
                    case "1":
                        //send to location inventory menu with ID = 1
                        Console.WriteLine("Sending you to the World of Bats menu");
                        break;
                    case "2":
                        //send to location inventory menu with ID = 2
                        Console.WriteLine("Sending you to the World of Games menu");
                        break;
                    case "3":
                        //send to location inventory menu with ID = 3
                        Console.WriteLine("Sending you to the World of Jerseys menu");
                        break;
                    case "4":
                        // send to location inventory menu with ID = 4
                        Console.WriteLine("Sending you to the World of Sticks menu");
                        break;
                    case "5":
                        //exit store
                        Console.WriteLine("Bye. Hope you come back soon.");
                        break;
                }
            } while (!locationID.Equals(5));
        }
    }
}
