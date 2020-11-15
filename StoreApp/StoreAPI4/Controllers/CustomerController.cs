using CustomerLib;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OrdersLib;
using StoreDB;
using StoreDB.Models;
using System;
using System.Collections.Generic;

namespace StoreAPI.Controllers
{
    public class Services
    {
        ICustomerService customerService;
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
        private readonly IStoreRepo storeRepo;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// order histories
        /// </summary>
        [HttpGet("get/history/{id}")]
        [Produces("application/json")]
        //415 unsupported media type header matches produces
        public IActionResult GetAllOrdersByCustomerID(int id)
        {
            try
            {
                CustomerModels customer = _customerService.GetCustomerByID(id);
                List<OrderModel> orders = _customerService.GetAllOrdersByCustomerID(customer.ID);
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
        [Produces("application/json")]
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
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest(); //doing this
            }
        }
        [HttpPost("signin")]
        [Consumes("application/json")]
        [Produces("application/json")]
        // 400 error same as above
        public IActionResult SignIn(CustomerModels customer)
        {
            try
            {
                CustomerModels returner = _customerService.GetCustomerByName(customer.Username);
                if (returner.email != customer.email)
                {
                    throw new Exception("this customer does not exist");
                }
                else
                {
                    return Ok();
                }
            }
            catch (Exception)
            {
                return BadRequest(); //doing this
            }
        }
    }
}
