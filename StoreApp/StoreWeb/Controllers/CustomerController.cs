using Microsoft.AspNetCore.Mvc;
using StoreWeb.Models;
using StoreWeb.Controllers ;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreWeb2.Models;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

/*namespace StoreWeb2.Controllers
{
    [Route("customer")]
    public class CustomerController : Controller
    {
        private Customer CurrentCustomer
        {
            get { return HttpContext.Session.Get<Customer>("CurrentCustomer"); }
            set { HttpContext.Session.Set("CurrentCustomer", value); }
        }
        private List<CartItem> Cart
        {
            get { return HttpContext.Session.Get<List<CartItem>>("Cart"); }
            set { HttpContext.Session.Set<List<CartItem>>("Cart", value); }
        }
        private List<LineItem> Order
        {
            get { return HttpContext.Session.Get<List<LineItem>>("Order"); }
            set { HttpContext.Session.Set<List<LineItem>>("Order", value); }
        }
        private Location location { get { return HttpContext.Session.Get<Location>("location"); } set { Cart = null; HttpContext.Session.Set<Location>("location", value); } }

        private readonly IActionResult LoginRedirectAction;
        private readonly Task<IActionResult> LoginRedirectActionTask;
        public CustomerController()
        {
            LoginRedirectAction = RedirectToAction("Login", "Home", "-1");
            LoginRedirectActionTask = Task.Factory.StartNew(() => LoginRedirectAction);
        }
        [Route("")]
        public async Task<IActionResult> Index()
        {
            if (CurrentCustomer == null)
            {
                return await LoginRedirectActionTask;
            }
            return await Task.Factory.StartNew(() => View(CurrentCustomer));
        }

        [Route("orders")]
        public async Task<IActionResult> GetOrderHistory(int? sortBy)
        {
            if(CurrentCustomer == null)
            {
                return await LoginRedirectActionTask;
            }
            string request = $"customer/get/orders/{CurrentCustomer.Username}";
            var orders = await this.GetDataAsync<List<Order>>(request);

            string location = $"location/get";
            var locations = await this.GetDataAsync<List<Location>>(locationrequest);

            foreach(Order order in orders)
            {
                order.LocationID = locations.Single(l => l.Id == order.LocationID);
            }

            List<Order> sortedOrders = orders;
            sortedOrders = sortBy switch
            {
                0 => orders.OrderBy(o => o.TimeOrderWasPlaced).ToList(),
                1 => orders.OrderBy(o => o.TimeOrderWasPlaced).Reverse().ToList(),
                2 => orders.OrderBy(o => o.Total).ToList(),
                3 => orders.OrderBy(o => o.Total).Reverse().ToList(),
                _ => orders
            };

            if (orders != default)
            {
                return View(sortedOrders);
            }
            else
            {
                return StatusCode(500);
            }
        }
        [Route("orders/details")]
        public async Task<IActionResult> ViewOrderDetails(int id)
        {
            if (CurrentCustomer == null)
            {
                return await LoginRedirectActionTask;
            }
            string request = $"order/products/get/{id}";
            var orderLineItems = await this.GetDataAsync<List<LineItem>>(request);
            string productsRequest = $"product/get";
            var receivedProducts = await this.GetDataAsync<List<Product>>(productsRequest);

            if (orderLineItems == null)
            {
                return StatusCode(500);
            }

            foreach (LineItem item in orderLineItems)
            {
                item.ProductID = receivedProducts.Single(p => p.Id == item.ProductID);
            }
            return View(orderLineItems);
        }

        [Route("add")]
        public ViewResult RegisterCustomer()
        {
            return View();
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> RegisterCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Customer newCustomer = new Customer(customer.Username, customer.Email);
                    await this.PostDataAsync($"customer/add", newCustomer);
                }
                catch (HttpRequestException e)
                {
                    ModelState.AddModelError(string.Empty, e.Message);
                    return View(customer);
                }
            }
            else return View(customer);
        }

        [Route("order")]
        public async Task<IActionResult> SetLocation()
        {
            if (CurrentCustomer == null)
            {
                return await LoginRedirectActionTask;
            }
            string request = $"location/get";
            var locations = await this.GetDataAsync<List<Location>>(request);

            return View(locations);
        }

        [Route("order/viewinventory/{locationid}")]
        public async Task<IActionResult> ViewInventoryAtLocation(int locationid)
        {
            if(location == null)
            {
                string requestLocation = $"location/get";
                var locations = await this.GetDataAsync<List<Location>>(requestLocation);
                location = locations.Where(l => l.Id == locationid).First();
            };
            if (CurrentCustomer == null)
            {
                return await LoginRedirectActionTask;
            }
            if(Cart == null)
            {
                Cart = new List<CartItem>();
            }
            string request = $"location/getinventory/{locationid}";
            var inventory = await this.GetDataAsync<List<Inventory>>(request);

            var processedInventory = ReturnInventoryWithoutCartItems(inventory, Cart);

            ViewData["Location"] = location.LocationName;
            ViewData["CartData"] = Cart;

            return View(processedInventory);
        }

        [Route("order/cart/view")]
        public async Task<IActionResult> ViewCart()
        {
            if(CurrentCustomer == null)
            {
                return await LoginRedirectActionTask;
            }
            if(Cart != null)
            {
                return View(Cart);
            }
            ModelState.AddModelError(string.Empty, "You have nothing in cart");
            return View(Cart);
        }

        [Route("order/cart/place")]
        public async Task<IActionResult> AddProductToCart(CartItem item)
        {
            if (CurrentCustomer == null)
            {
                return await LoginRedirectActionTask;
            }
            if (Cart == null)
            {
                Cart = new List<CartItem>();
            }
            CartItem processedItems = await GetProductForCartItem(item);
            List<CartItem> tempCart = Cart;

            try
            {
                tempCart.Where()
            }
        }
    }
} */