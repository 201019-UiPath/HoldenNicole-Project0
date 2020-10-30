using CustomerLib;
using StoreDB;
using StoreDB.Models;
using System.Collections.Generic;
using System;
namespace StoreBL
{
    public class StoreBLL //errors are all from having no data yet
    {
        private string userInput;

        private CustomerMenu customerMenu;
        private CustomerLocationMenu customerLocationMenu;
        private CustomerOrderHistoryMenu customerOrderHistoryMenu;
        private CustomerSearch customerSearch;
        private LocationInventoryMenu locationInventoryMenu;
        private LocationOrderHistoryMenu locationOrderHistoryMenu;
        private ManagerLocationInventory managerLocationInventory;
        private SearchBySport searchBySport;
        private SearchByType searchByType;
        private SignInMenu signInMenu;
        private SportOrderHistoryMenu sportOrderHistoryMenu;
        private TypeOrderHistoryMenu typeOrderHistoryMenu;
        private AthleteOrderHistoryMenu athleteOrderHistoryMenu;
        private ManagerWorldOfBats managerWorldOfBats;
        private ManagerWorldOfGames managerWorldOfGames;
        private ManagerWorldOfJerseys managerWorldOfJerseys;
        private ManagerWorldOfSticks managerWorldOfSticks;

        IRepository repo = new FileRepo();

        public void AddCustomer(Customer newCustomer)
        {
            ///take in user input and check if email and username in use
            System.Console.WriteLine("Please enter the email you would like to use to sign up:");
            email = Console.ReadLine();
            if (!List<Emails>.Contains(email))
            {
                Console.WriteLine("Please enter a user name: ");
                string userName = Console.ReadLine();
                if (!(List<UserNames>.Contains(UserName)))
                {
                    System.Console.WriteLine($"New user created with user name: {UserName}");
                    customerMenu.Start();
                }
                else
                {
                    System.Console.WriteLine("Sorry this user name already exists please try another user name.");
                }
            }
            else
            {
                System.Console.WriteLine("Sorry this email is already a registered user. Try signing in.");
            }
            repo.AddCustomerAsync(newCustomer); 
        } 
        public void CheckCustomer(Customer customerUserName)
        {
            // take username from sign in 
            if (List<CustomerUserNames>.contains(customerUserName))
            {
                customerMenu.Start();
            }
        } 
        public void CheckManager(Manager managerName){
                // take 
            if (List<ManagerNames>.contains(managerName))
                {
                System.Console.WriteLine($"Welcome back {managerName.UserName}");
                ///want to compare this manager name and pull the corresponding location
                int location = manager.LocationID;
                switch (location)
                {
                    case "1":
                        System.Console.WriteLine("Redirecting you to World of Bats Menu");
                        managerWorldOfBats.Start();
                        break;
                    case "2":
                         System.Console.WriteLine("Redirecting you to World of Games Menu");
                         managerWorldOfGames.Start();
                         break;
                     case "3":
                        System.Console.WriteLine("Redirecting you to World of Sticks Menu");
                        managerWorldOfSticks();
                        break;
                     case "4":
                        System.Console.WriteLine("Redirecting you to World of Jerseys Menu");
                        managerWorldOfJerseys.Start();
                        break;
                    default:
                        System.Console.WriteLine("Could not connect you to your location. Please try again.");
                        signInMenu.Start();
                        break;
                }
            }
        } 
    }
}
