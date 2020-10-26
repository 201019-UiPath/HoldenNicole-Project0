using ManagerLib;
using System;

namespace StoreUI.Menus
{
    class ManagerMenu : IMenu
    {
        StoreBL.StoreBLL storeBL = new StoreBL.StoreBLL();
        public void Start()
        {
            Manager manager = new Manager();
            Console.WriteLine($"Howdy, {manager.ManagerName}");
            Console.WriteLine("What would you like to do today?");
            Console.WriteLine($"[1] View order history /n [2] View inventory for {manager.LocationName} /n [3] exit");
            string managerInput = Console.ReadLine();
            do
            {
                switch (managerInput)
                {
                    case "1":
                        Console.WriteLine($"Redirecting you to order history menu for {manager.LocationName}.");
                        //redirect to location order history menu
                        break;
                    case "2":
                        Console.WriteLine($"Redirecting you to the inventory menu for {manager.LocationName}");
                        //redirect to the manager inventory menu
                        break;
                    case "3":
                        Console.WriteLine("Come back again soon.");
                        // exit program
                        break;
                }
            } while (!managerInput.Equals("3"));
            
        }
    }
}
