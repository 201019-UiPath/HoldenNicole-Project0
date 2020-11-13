using CustomerLib;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OrdersLib;
using StoreDB.Models;
using System;
using System.Collections.Generic;

namespace StoreAPI.Controllers
{
    public class Services
    {
        ICustomerService customerService;
        ICartService cartService;
    }
    [Route("[controller]")]
    [ApiController]
    [EnableCors("_allowed")]
    public class CustomerController : ControllerBase
    {
        /// <summary>
        /// BL methods here
        /// </summary>
        private readonly ICustomerService _customerService;
        private readonly ICartService _cartService;
        public CustomerController(Services service)
        {
            this._customerService = new CustomerService();
            this._cartService = new CartService();
        }
        /// <summary>
        /// order histories
        /// </summary>
        [HttpGet("getHistory/{customer}")]
        [Produces("application/json")]

        public IActionResult GetAllOrdersByCustomerID(CustomerModels customer)
        {
            try
            {
                return Ok(_customerService.GetAllOrdersByCustomerIDDateAscending(customer));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        /// <summary>
        /// Add customer
        /// </summary>
        [HttpPost("register")]
        [Consumes("application/json")]
        [Produces("application/json")]
        //giving 405 error
        public IActionResult Register(CustomerModels newCustomer)
        {
            try
            {
                List<CustomerModels> getCustomersTask = _customerService.GetAllCustomers();
                foreach (var h in getCustomersTask)
                {
                    if (newCustomer.Username.Equals(h.Username))
                    {
                        throw new Exception("Sorry this username is already taken");
                    }
                    else
                    {
                        if (newCustomer.email.Equals(h.email))
                        {
                            throw new Exception("Sorry this email is already registered");
                        }
                    }
                }
                _customerService.AddCustomer(newCustomer);
                CartsModel cart = new CartsModel();
                cart.CustomerID = newCustomer.ID;
                _cartService.AddCart(cart);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost("signin")]
        [Consumes("application/json")]
        [Produces("application/json")]
        // 405 error
        public IActionResult SignIn(CustomerModels customer)
        {
            try
            {
                CustomerModels returner = _customerService.GetCustomerByName(customer.Username);
                if (returner.email != customer.email)
                {
                    throw new Exception();
                }
                else
                {
                    return Ok();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
