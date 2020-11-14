using LocationLib;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using StoreDB.Models;

namespace StoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors("_allowed")]
    public class LocationController : Controller
    {
        /// <summary>
        /// will include location and inventory services
        /// </summary>
        private readonly ILocationService _locationService;
        private readonly IInventoryService _inventoryService;

        public LocationController(ILocationService locationService, IInventoryService inventoryService)
        {
            _locationService = locationService;
            _inventoryService = inventoryService;
        }

        /// <summary>
        /// order history by locations
        /// </summary>
        [HttpGet("get/history/{id}")]
        [Produces("application/json")]
        //giving 400 error so going to catch block
        public IActionResult GetAllOrdersByLocationIDDateAscending(int id)
        {
            try
            {
                return Ok(_locationService.GetAllOrdersByLocationID(id));
            }
            catch (Exception)
            {
                return StatusCode(400); //coming here so return messed up
            }
        }

        /// <summary>
        /// manager modifying inventory
        /// </summary>
        [HttpPost("add/product/{locationid}/{productid}/{quantity}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        //415 error return type problem
        public IActionResult AddProductToLocation(InventoryModel item, int quantity)
        {
            try
            {
                _locationService.AddProductToLocation(item, quantity);
                return CreatedAtAction("AddProductToLocation", (item, quantity));
            }
            catch (Exception)
            {
                return BadRequest();//doing this
            }
        }

        [HttpDelete("delete/product/{locationid}/{productid}/{quantity}")]
        //500 error processing request
        public IActionResult DeleteProductAtLocation(int locationid, int productid, int quantity)
        {
            try
            {
                _locationService.DeleteProductAtLocation(locationid, productid, quantity);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500); //doing this
            }
        }

        /// <summary>
        /// shows manager current inventory at location
        /// </summary>

        [HttpGet("get/inventory/{id}")]
        [Produces("application/json")]
        // going into catch block
        public IActionResult ViewAllProductsAtLocation(int id)
        {
            try
            {
                return Ok(_inventoryService.ViewAllProductsAtLocation(id));
            }
            catch (Exception)
            {
                return NotFound(); //doing this matches shaelies but still doesnt work
            }
        }

    }
}
