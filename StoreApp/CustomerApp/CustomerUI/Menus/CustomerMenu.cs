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
        ProductBL productBL = new ProductBL();
        OrderBL orderBL = new OrderBL();
        public void Start(){
            System.Console.WriteLine("Howdy! Welcome to Sports Authenticated!");
            System.Console.WriteLine("What would you like to do today? Type in the number you would like to do from this menu:");
            System.Console.WriteLine("[0] View Products /n [1] Create order /n [2] View your order history /n [3] Exit");
            
            string customerInput = System.Console.ReadLine();
            do{
                switch (customerInput){
                    case "0":
                        System.Console.WriteLine("How would you like to view the products? Type in the corresponding number: ");
                        System.Console.WriteLine("[0] View all products /n [1] View products by location [2] View products by sport /n [3] View products by athlete /n [4] View type of autographed item /n [5] Exit");
                        string customerInput2 = System.Console.ReadLine();
                        do{
                            switch (customerInput2){
                                case "0":
                                    List<ProductDB> allProducts = productBL.GetAllProducts();
                                    foreach (var product in allProducts)
                                    {
                                        System.Console.WriteLine($"Items {product.Name}");
                                    }
                                    break;
                                case "1":
                                    List<ProductDB> locationProducts = productBL.GetAllProductsByLocation();
                                    foreach (var location in locationProducts){
                                        System.Console.WriteLine($"Items {location.Location}");
                                    }
                                    break;
                                case "2":
                                    List<ProductDB> sportProducts = productBL.GetAllProductsBySport();
                                    foreach (var sport in sportProducts)
                                    {
                                        System.Console.WriteLine($"Items {sport.Sport}");
                                    }
                                    break;
                                case "3":
                                    List<ProductDB> athleteProducts = productBL.GetAllProductsByAthlete();
                                    foreach (var athlete in athleteProducts)
                                    {
                                        System.Console.WriteLine($"Items {athlete.Athlete}");
                                    }
                                    break;
                                case "4":
                                    List<ProductDB> typeProducts = productBL.GetAllProductsByType();
                                    foreach (var type in typeProducts){
                                        System.Console.WriteLine($"Items {type.Type}");
                                    }
                                    break;
                                default:
                                    System.Console.WriteLine("Invalid input! Please select a valid option!");
                                    break;
                            }
                        } while(!customerInput2.Equals("5"));

                    case "1":
                        OrderDB newOrder = GetOrderID();
                        orderBL.AddOrder(newOrder);
                        System.Console.WriteLine($"Order {newOrder.Name} was created");//want to add items in order
                        
                        //need to add functionality to add to this order
                        //need to also add functionality to place order

                    case "2":
                        

                    case "3":

                    default:
                }
            }
        }
        
    }
}