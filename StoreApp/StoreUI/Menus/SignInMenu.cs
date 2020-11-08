using CustomerLib;
using ManagerLib;
using Serilog;
using StoreDB.Entities;
using StoreDB.Models;
using System;

namespace StoreUI.Menus
{
    public class SignInMenu : IMenu
    {
        private string userInput;
        private CustomerMenu customerMenu;
        private SignInMenu signInMenu;
        private ManagerMenu managerMenu;
        private ixdssaucContext storeContext1;
        private StoreMapper storeMapper;
        private readonly ixdssaucContext storeContext;
        private readonly CustomerService customerService;
        private readonly ManagerSevices managerSevices;
        private DBRepo dBRepo;
        public SignInMenu(ixdssaucContext context, IMapper mapper)
        {
            this.customerMenu = new CustomerMenu(new CustomerModels(), new ixdssaucContext(), new StoreMapper());
            this.managerMenu = new ManagerMenu(new ManagerModel(), new ixdssaucContext(), new StoreMapper());
        }

        public SignInMenu(ixdssaucContext storeContext1, StoreMapper storeMapper)
        {
            this.storeContext1 = storeContext1;
            this.storeMapper = storeMapper;
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
                    ManagerModel manager = ManagerSignIn();
                    break;
                case "2":
                    CustomerModels customer = CustomerSignIn();
                    break;
                case "3":
                    CustomerModels newCustomer = Registration();
                    break;
                case "4":
                    Console.WriteLine("Bye come again some other time.");
                    Log.Information("seriously????");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Input please try again");
                    signInMenu = new SignInMenu(storeContext, storeMapper);
                    signInMenu.Start();
                    Log.Information("invalid input");
                    break;
            }
        }
        public CustomerModels CustomerSignIn()
        {
            CustomerModels customer = new CustomerModels();

            Console.WriteLine("Please enter your username:");
            string returningCustomerUserName = Console.ReadLine();
            try
            {
                //validation brakes the functional code
                // customer = customerService.GetCustomerByName(returningCustomerUserName);
                CustomerModels returningCustomer = customer;
                Orders orders = new Orders();
                Orders newOrder = orders;
                newOrder.Customer = (int)returningCustomer.ID;
                customerMenu = new CustomerMenu(customer, storeContext, new StoreMapper());
                customerMenu.Start();
                Log.Information("Returning customer sighted");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"There is no registered user with the username: {customer.Username}");
            }
            return customer;
        }
        public ManagerModel ManagerSignIn()
        {
            Console.WriteLine("Please enter your username:");
            string Username = Console.ReadLine();
            ManagerModel managerModel = new ManagerModel();
            dBRepo = new DBRepo();
            try
            {
                managerModel = dBRepo.GetManagerByName(Username);
                //validation breaks my functional code
                managerMenu = new ManagerMenu(managerModel, storeContext, new StoreMapper());
                managerMenu.Start();
                /// would like to validate this but idk how
                ///if output from dBRepo contains user input redirect to location corresponding to manager
                Log.Information("manager sighted");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"There is no manager with username: {managerModel.Username}");
            }
            return managerModel;
        }
        public CustomerModels Registration()
        {
            Console.WriteLine("Please enter the username you would like to use:");
            string Name = Console.ReadLine();
            Console.WriteLine("Please enter your email address:");
            string email = Console.ReadLine();
            var newCustomer = new CustomerModels()
            {
                Username = Name,
                email = email,
            };
            customerMenu = new CustomerMenu(newCustomer, storeContext, new StoreMapper());
            customerMenu.Start();
            Log.Information("New customer sighted");
            return newCustomer;
        }
    }
}