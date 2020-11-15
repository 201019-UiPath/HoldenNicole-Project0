using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerLib;
using LocationLib;
using Microsoft.AspNetCore.Cors;
using StoreDB.Models;

namespace StoreAPI4.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors("_allowed")]
    public class SignInController : Controller
    {
        private readonly ICustomerService customerService1;
        private readonly ILocationService locationService1;

        public SignInController(ICustomerService customerService, ILocationService locationServices)
        {
            ICustomerService customerService1 = customerService;
            ILocationService locationService1 = locationServices;
        }
        [HttpPost("register")]
        [Consumes("appliction/json")]
        [Produces("application/json")]
        public IActionResult Register(CustomerModels customer)
        {
            try
            {
                CustomerModels newCustomer = customerService1.AddCustomer(customer);
                CustomerModels customers = customerService1.GetCustomerByName(newCustomer.Username);
                CartsModel cart = new CartsModel();
                cart.CustomerID = customers.ID;
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost("signIn/customer")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult SignInCustomer(CustomerModels customer)
        {
            try
            {
                CustomerModels signInCustomer = customerService1.GetCustomerByName(customer.Username);
                string userName = signInCustomer.Username;
                return Ok(signInCustomer);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost("signIn/manager")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult SignInManager(ManagerModel manager)
        {
            try
            {
                ManagerModel signInManager = locationService1.GetManagerByName(manager.Username);
                string Username = signInManager.Username;
                return Ok(signInManager);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
