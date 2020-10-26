using CustomerLib;
using ManagerLib;
using StoreDB;
using System.Collections.Generic;
namespace StoreBL
{
    public class StoreBLL //errors are all from having no data yet
    {
        IRepository repo = new FileRepo();

        public void AddCustomer(Customer newCustomer)
        {
            // take in UserName, Email, and ShippingAddress from sign up menu
            // compare to list of CustomerIDs, UserNames, and Emails
            if (!List<Emails>.Contains(Email))
            {

                if (!(List<UserNames>.Contains(UserName)))
                {
                    System.Console.WriteLine($"New user created with user name: {UserName}");
                    System.Console.WriteLine("Redirecting you to Customer menu");
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
                System.Console.WriteLine($"Welcome back {customerUserName.UserName}");
                System.Console.WriteLine("Which would you like to do?");
                System.Console.WriteLine("[1] view order history /n [2] go to customer menu /n [3] exit store");
                string userInput = System.Console.ReadLine();
                do
                {
                    switch (userInput)
                    {
                        case "1":
                            System.Console.WriteLine("Redirecting you to order history menu");
                            // send to customer order history menu
                            break;
                        case "2":
                            System.Console.WriteLine("Redirecting you to main customer menu");
                            //send to main customer menu
                            break;
                        case "3":
                            System.Console.WriteLine("Hope you come back to Sports Authenticated soon");
                            break;
                    }
                } while (!(userInput.Equals(3)));
            }
        } 
        public void CheckManager(Manager managerName){
                // take 
            if (List<ManagerNames>.contains(managerName))
                {
                System.Console.WriteLine($"Welcome back {managerName.ManagerName}");
                    System.Console.WriteLine("Which location inventory would you like to look at?");
                    System.Console.WriteLine("[1] World of Bats /n [2] World of Sports /n [3] World of Sticks /n [4] World of Jerseys /n [5] exit");
                    string location = System.Console.ReadLine();
                    do
                    {
                        switch (location)
                        {
                            case "1":
                                System.Console.WriteLine("Redirecting you to World of Bats Menu");
                                // send to World of Bats menu
                                break;
                            case "2":
                                System.Console.WriteLine("Redirecting you to World of Sports Menu");
                                //send to World of Sports menu
                                break;
                            case "3":
                                System.Console.WriteLine("Redirecting you to World of Sticks Menu");
                                //send to World of Sticks Menu
                                break;
                            case "4":
                                System.Console.WriteLine("Redirecting you to World of Jerseys Menu");
                                //send to World of Jerseys Menu
                                break;
                            case "5":
                                System.Console.WriteLine("Bye come back again soon");
                                break;
                        }

                    } while (!(location.Equals(5)));
                }
        } 
    
    }
}
