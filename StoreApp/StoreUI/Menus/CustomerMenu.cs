using System;
using CustomerLib;

namespace StoreUI.Menus
{
    class CustomerMenu : IMenu
    {
        public void Start()
        {
            Customer customer = new Customer();
            //retrieve customer info from sign in menu
            Console.WriteLine($"Howdy {customer.UserName}! What would you like to do today at Sports Authenticated?");
            Console.WriteLine("[1] View your order history /n [2] Shop at a specific store /n [3] Search entire inventory /n [4] exit store");
            string customerInput = Console.ReadLine();
            do
            {
                switch (customerInput)
                {
                    case "1":
                        //redirect to customer order history
                        Console.WriteLine("Redirecting you to your order history");
                        break;
                    case "2":
                        //redirect to location menu
                        Console.WriteLine("Redirecting you to the location menu. Hope you find something you like.");
                        break;
                    case "3":
                        //redirect to customer search menu
                        Console.WriteLine("Redirecting you to the search menu");
                        break;
                    case "4":
                        //exit store
                        Console.WriteLine("Come back again soon");
                        break;
                }
            } while (!customerInput.Equals(4));
        }
    }
}
