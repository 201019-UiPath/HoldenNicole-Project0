using CustomerLib;
using CustomerBL;
using System.Text.RegularExpressions;
using System.Collections.Generic;
namespace CustomerUI.Menus
{
    /// <summary>
    /// welcome menu for customers to see
    /// </summary>
    public class CustomerMenu:IMenu
    {
        CustomerBL customerBL = new CustomerBL();
        public void Start(){
            System.Console.WriteLine("Howdy! Welcome to Sports Authenticated!");
            System.Console.WriteLine("What would you like to do today? Type in the number you would like to do from this menu:");
            System.Console.WriteLine("[1] Place an Order /n [1] Check what is in stock /n [2] Search for items by person/sport/item /n [3] Exit");
            
            string customerInput = System.Console.ReadLine();
        }
        
    }
}