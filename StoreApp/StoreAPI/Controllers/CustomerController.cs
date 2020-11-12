using CustomerLib;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreDB.Entities;
using StoreDB.Models;
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
            _customerService=customerService;
        }
        /// <summary>
        /// order histories
        /// </summary>
        [HttpGet("getHistory/{customer}")]
        [Produces("application/json")]
        [EnableCors("_allowed")]
        //[FormatFilter]
        public IActionResult GetAllOrdersByCustomerIDDateAscending(CustomerModels customer)
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
/*
        [HttpGet("get/{customer}")]
        [Produces("application/json")]
        public IActionResult GetAllOrdersByCustomerIDDateDescending(CustomerModels customer)
        {
            try
            {
                return Ok(_customerService.GetAllOrdersByCustomerIDDateDescending(customer));
            }
            catch (Exception)
            {
                return StatusCode(520);
            }
        }

        [HttpGet("get/{customer}")]
        [Produces("application/json")]
        public IActionResult GetAllOrdersByCustomerIDPriceAscending(CustomerModels customer)
        {
            try
            {
                return Ok(_customerService.GetAllOrdersByCustomerIDPriceAscending(customer));
            }
            catch (Exception)
            {
                return StatusCode(520);
            }
        }

        [HttpGet("get/{customer}")]
        [Produces("application/json")]
        public IActionResult GetAllOrdersByCustomerIDPriceDescending(CustomerModels customer)
        {
            try
            {
                return Ok(_customerService.GetAllOrdersByCustomerIDPriceDescending(customer));
            }
            catch (Exception)
            {
                return StatusCode(520);
            }
        } */
        /// <summary>
        /// Add customer
        /// </summary>
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
