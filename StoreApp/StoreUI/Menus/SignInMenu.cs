using CustomerLib;
using ManagerLib;
using StoreBL;
using System.Text.RegularExpressions;
using System.Collections.Generic;
namespace StoreUI.Menus
{
    public class SignInMenu : IMenu
    {
        StoreBL storeBL = new StoreBL();
        public void Start(){
            System.Console.WriteLine("Howdy! Welcome to Sports Authenticated!");
            System.Console.WriteLine("Please select the option matching you below:");
            System.Console.WriteLine("[0] Sign in as a manager /n [1] Sign in as a returning customer /n [2] Sign up as a new user /n [3] exit");
            string userInput = System.Console.ReadLine();
            do{
                switch (userInput){
                    case "0":
                        System.Console.WriteLine("Please enter your username:");
                        string userName = System.Console.ReadLine();
                        storeBL.CheckManager(userName);
                        System.Console.WriteLine($"Welcome back {userName.ManagerUserName}");
                        //send to manager menu
                        break;
                    case "1":
                        System.Console.WriteLine("Please enter your username:");
                        string returningCustomerUserName = System.Console.ReadLine();
                        storeBL.CheckCustomer(returningCustomerUserName);
                        System.Console.WriteLine($"Welcome back {returningCustomerUserName.CustomerUserName}");
                        //send to customer menu
                        break;
                    case "2":
                        System.Console.WriteLine("Please enter your name: ");
                        string customerName = System.Console.ReadLine();
                        System.Console.WriteLine("Please enter your email: ");
                        string email = System.Console.ReadLine();
                        storeBL.AddCustomer();
                        //need to add implementation to check
                        //if new user passes then send to customer menu
                        break;
                    case "3":
                        System.Console.WriteLine("Bye come again some other time.");
                        break;
                }
            } while(!userInput.Equals("3")); 
        }
    }
}