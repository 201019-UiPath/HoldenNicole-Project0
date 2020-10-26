using ProductLib;
using System;

namespace StoreUI.Menus
{
    class CustomerSearch : IMenu
    {
        public void Start()
        {
            Product product = new Product();
            System.Console.WriteLine("What would you like to search by in the entire Sports Authenticated inventory today?");
            System.Console.WriteLine("[1] Search by sport /n [2] Search by type of item /n [3] Search by person /n [4] exit store");
            string searchSelection = Console.ReadLine();
            do
            {
                switch (searchSelection)
                {
                    case "1":
                        Console.WriteLine("Sending you to the search by sport menu");
                        //redirect to search by sport menu
                        break;
                    case "2":
                        Console.WriteLine("Sending you to the search by type of item menu");
                        //redirect to search by item menu
                        break;
                    case "3":
                        Console.WriteLine("Sending you to the search by person menu");
                        //redirect to search by person menu
                        break;
                    case "4":
                        Console.WriteLine("Bye hope you come again soon");
                        // exit store
                        break;
                }
            } while (!searchSelection.Equals(4));
        }
    }
}
