using StoreDB;
using StoreDB.Entities;
using Serilog;

namespace StoreUI.Menus
{
    public class ManagerMenu : IMenu
    {
        private SignInMenu signInMenu;
        private ManagerWorldOfBats managerWorldOfBats;
        private ManagerWorldOfGames managerWorldOfGames;
        private ManagerWorldOfJerseys managerWorldOfJerseys;
        private ManagerWorldOfSticks managerWorldOfSticks;
        private ManagerMenu managerMenu;
        private StoreContext storeContext;
        private StoreMapper storeMapper;
        private Managers manager;
        public ManagerMenu(Managers manager, StoreContext storeContext, StoreMapper storeMapper)
        {
            this.manager = manager;
            this.storeContext = storeContext;
            this.storeMapper = storeMapper;
        }
        public void Start()
        {
            System.Console.WriteLine("Which store are you the manager of?");
            System.Console.WriteLine("[1] World of Bats");
            System.Console.WriteLine("[2] World of Sticks");
            System.Console.WriteLine("[3] World of Jerseys");
            System.Console.WriteLine("[4] World of Games");
            System.Console.WriteLine("[5] Back to Sign in menu");
            string userInput = System.Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    System.Console.WriteLine("Sending you to the World of Bats store");
                    managerWorldOfBats = new ManagerWorldOfBats(manager, storeContext, new StoreMapper());
                    managerWorldOfBats.Start();
                    Log.Information("Cob");
                    break;
                case "2":
                    System.Console.WriteLine("Sending you to the World of Sticks branch");
                    managerWorldOfSticks = new ManagerWorldOfSticks(manager, storeContext, new StoreMapper());
                    managerWorldOfSticks.Start();
                    Log.Information("Great One");
                    break;
                case "3":
                    System.Console.WriteLine("Sending you to the World of Jerseys branch");
                    managerWorldOfJerseys = new ManagerWorldOfJerseys(manager, storeContext, new StoreMapper());
                    managerWorldOfJerseys.Start();
                    Log.Information("Miracle Team");
                    break;
                case "4":
                    System.Console.WriteLine("Sending you to the World of Games branch");
                    managerWorldOfGames = new ManagerWorldOfGames(manager, storeContext, new StoreMapper());
                    managerWorldOfGames.Start();
                    Log.Information("Heisman");
                    break;
                case "5":
                    signInMenu = new SignInMenu(storeContext, storeMapper);
                    signInMenu.Start();
                    Log.Information("wrong choice?");
                    break;
                default:
                    managerMenu.Start();
                    Log.Information("invalid option try again");
                    break;
            }
        }
    }
}