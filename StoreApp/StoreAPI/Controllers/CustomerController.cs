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
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        /// <summary>
        /// order histories
        /// </summary>
        [HttpGet("get/history/{customer}")]
        [Produces("application/json")]
        //415 unsupported media type
        public IActionResult GetAllOrdersByCustomerID(CustomerModels customer)
        {
            try
            {
                List<OrderModel> orders = new List<OrderModel>();
                orders = _customerService.GetAllOrdersByCustomerIDDateAscending(customer);
                return Ok(orders);
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
        //giving 400 error: "The JSON value could not be converted to StoreDB.Models.CustomerModels
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
        // 400 error same as above
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
