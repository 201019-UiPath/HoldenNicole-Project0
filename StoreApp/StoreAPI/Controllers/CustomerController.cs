using CustomerLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        /// <summary>
        /// BL methods here
        /// </summary>
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        //unnecessary except when modified to get order history for customer
        [HttpGet("get")]
        [Produces("application/json")]
        public IActionResult GetAllCustomers()
        {
            try
            {
                return Ok(_customerService.GetAllCustomers());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        // if returns exception then the username is available
        [HttpGet("get/{username}")]
        [Produces("application/json")]
        public IActionResult GetCustomerByUsername(string username)
        {
            try
            {
                return Ok(_customerService.GetCustomerByName(username));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        // if returns exception then the email is available
        [HttpGet("get/{email}")]
        [Produces("application/json")]
        public IActionResult GetCustomerByEmail(string email)
        {
            try
            {
                return Ok(_customerService.GetCustomerByEmail(email));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }


        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddCustomer(Customer newCustomer)
        {
            try
            {
                _customerService.AddCustomer(newCustomer);
                return CreatedAtAction("AddCustomer", newCustomer);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } 
    } 
}
