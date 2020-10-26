using CustomerLib;
using ManagerLib;
using System;
namespace StoreUI.Menus
{
    public class SignInMenu : IMenu
    {
        StoreBL.StoreBLL storeBL = new StoreBL.StoreBLL();
        public void Start(){
            System.Console.WriteLine("Howdy! Welcome to Sports Authenticated!");
            System.Console.WriteLine("Please select the option matching you below:");
            System.Console.WriteLine("[1] Sign in as a manager /n [2] Sign in as a returning customer /n [3] Sign up as a new customer /n [4] exit");
            string userInput = System.Console.ReadLine();
            do{
                switch (userInput){
                    case "1":
                        Manager manager = new Manager();
                        System.Console.WriteLine("Please enter your username:");
                        string managerUserName = System.Console.ReadLine();
                        storeBL.CheckManager(manager);
                        System.Console.WriteLine($"Welcome back {manager.ManagerName}");
                        // manager name should be linked to location
                        /// <summary>
                        /// send to location corresponding to manager's location
                        /// </summary>
                        break;
                    case "2":
                        Customer customer = new Customer();
                        System.Console.WriteLine("Please enter your username:");
                        string returningCustomerUserName = System.Console.ReadLine();
                        storeBL.CheckCustomer(customer);
                        System.Console.WriteLine($"Welcome back {customer.UserName}");
                        Console.WriteLine("Hope you find something you like!");
                        /// <summary>
                        /// send to customer menu
                        /// </summary>
                        break;
                    case "3":
                        Customer newCustomer = new Customer();
                        storeBL.AddCustomer(newCustomer);
                        /// <summary>
                        /// 
                        /// if pass add to customer list then
                        /// send to customer menu otherwise give message try again
                        /// </summary>
                        break;
                    case "4":
                        System.Console.WriteLine("Bye come again some other time.");
                        /// <summary>
                        /// leave menu
                        /// </summary>
                        break;
                }
            } while(!userInput.Equals("4")); 
        }
        
    }
}