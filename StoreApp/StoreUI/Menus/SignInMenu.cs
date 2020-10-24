using CustomerLib;
using ManagerLib;
using StoreBL;
using System.Text.RegularExpressions;
using System.Collections.Generic;
namespace StoreUI.Menus
{
    public class SignInMenu : IMenu
    {
        //StoreBL storeBL = new StoreBL();
        public void Start(){
            System.Console.WriteLine("Howdy! Welcome to Sports Authenticated!");
            System.Console.WriteLine("Please select the option matching you below:");
            System.Console.WriteLine("[1] Sign in as a manager /n [2] Sign in as a returning customer /n [3] Sign up as a new customer /n [4] exit");
            string userInput = System.Console.ReadLine();
            do{
                switch (userInput){
                    case "1":
                        Manager manager = GetManagerDetails();
                        System.Console.WriteLine("Please enter your username:");
                        string userName = System.Console.ReadLine();
                        manager.CheckManager(userName);
                        System.Console.WriteLine($"Welcome back {userName.ManagerUserName}");
                        /// <summary>
                        /// send to manager menu
                        /// </summary>
                        break;
                    case "2":
                        System.Console.WriteLine("Please enter your username:");
                        string returningCustomerUserName = System.Console.ReadLine();
                        storeBL.CheckCustomer(returningCustomerUserName);
                        System.Console.WriteLine($"Welcome back {returningCustomerUserName.CustomerUserName}");
                        /// <summary>
                        /// send to customer menu
                        /// </summary>
                        break;
                    case "3":
                        Customer newCustomer = GetCustomerDetails();
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