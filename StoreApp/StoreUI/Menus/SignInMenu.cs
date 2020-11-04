using StoreUI.Entities;
using System;
using Serilog;
using CustomerLib;
using OrdersLib;
using LocationLib;

namespace StoreUI.Menus
{
    public class SignInMenu : IMenu
    {
        private string userInput;
        private CustomerMenu customerMenu;
        private SignInMenu signInMenu;
        private ManagerMenu managerMenu;
        private ixdssaucContext storeContext;
        private CustomerService customerService;
        private CartItemService cartService;
        private LocationService locationService;
        public SignInMenu(ixdssaucContext context, IMapper mapper)
        {
            this.customerMenu = new CustomerMenu(new Customer(), new ixdssaucContext(), new StoreMapper());
            this.managerMenu = new ManagerMenu(new Managers(), new ixdssaucContext(), new StoreMapper());
        }
        public void Start()
        {
            Console.WriteLine("Howdy! Welcome to Sports Authenticated!");
            Console.WriteLine("Please select the option matching you below:");
            Console.WriteLine("[1] Sign in as a manager");
            Console.WriteLine("[2] Sign in as a returning customer");
            Console.WriteLine("[3] Sign up as a new customer");
            Console.WriteLine("[4] exit");
            userInput = Console.ReadLine();
            
            switch (userInput)
            {
                case "1":
                    Managers manager = ManagerSignIn();
                    break;
                case "2":
                    Customer customer = CustomerSignIn();
                    break;
                case "3":
                    Customer newCustomer = Registration();
                    break;
                case "4":
                    Console.WriteLine("Bye come again some other time.");
                    Log.Information("seriously????");
                    break;
                default:
                    Console.WriteLine("Invalid Input please try again");
                    signInMenu.Start();
                    Log.Information("invalid input");
                    break;
            }
        }
        public Customer CustomerSignIn()
        {
            Customer customer = new Customer();
            
            Console.WriteLine("Please enter your username:");
            string returningCustomerUserName = Console.ReadLine();
            try 
            {
                //validation brakes the functional code
                //customer = customerService.GetCustomerByName(returningCustomerUserName);
                //Customers returningCustomer = customer;
                //Orders newOrder = new Orders();
                //newOrder.CustomerID = returningCustomer.ID;
                customerMenu = new CustomerMenu(customer, storeContext, new StoreMapper());
                customerMenu.Start();
                Log.Information("Returning customer sighted");
            }
            catch(InvalidOperationException)
            {
                System.Console.WriteLine($"There is no registered user with the username: {customer.Username}");
            }
            return customer;
        }
        public Managers ManagerSignIn()
        {
            Managers manager = new Managers();
            Console.WriteLine("Please enter your username:");
            string managerUserName = Console.ReadLine();
            try
            {
                //validation breaks my functional code
                //manager = locationService.GetManagerByName(managerUserName);
                managerMenu = new ManagerMenu(manager, storeContext, new StoreMapper());
                managerMenu.Start();
                /// would like to validate this but idk how
                ///if output from dBRepo contains user input redirect to location corresponding to manager
                Log.Information("manager sighted");
            }
            catch(InvalidOperationException)
            {
                System.Console.WriteLine($"There is no manager with username: {manager.Username}");
            }       
            return manager;
        }
        public Customer Registration()
        {
            System.Console.WriteLine("Please enter the username you would like to use:");
            string Name = Console.ReadLine();
            System.Console.WriteLine("Please enter your email address:");
            string email = Console.ReadLine();
            System.Console.WriteLine("Please enter your address: ");
            string address = Console.ReadLine();
            var newCustomer = new Customer()
            {
                Username = Name,
                Email = email,
            };
            customerMenu = new CustomerMenu(newCustomer, storeContext, new StoreMapper());
            customerMenu.Start();
            Log.Information("New customer sighted");
            return newCustomer;
        }
    }
}