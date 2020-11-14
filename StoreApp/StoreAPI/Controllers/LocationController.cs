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
        //giving 500 error: processing request
        public IActionResult GetAllOrdersByLocationIDDateAscending(int id)
        {
            try
            {
                return Ok(_locationService.GetAllOrdersByLocationIDDateAscending(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// manager modifying inventory
        /// </summary>
        [HttpPost("add/product/{locationid}/{productid}/{quantity}")]
        [Consumes("application/json")]
        //400 error service error again
        public IActionResult AddProductToLocation(int locationid, int productid, int quantity)
        {
            try
            {
                _locationService.AddProductToLocation(locationid, productid, quantity);
                return CreatedAtAction("AddProductToLocation", (locationid, productid, quantity));
            }
            catch (Exception)
            {
                return BadRequest();//doing this
            }
        }

        [HttpDelete("delete/product/{locationid}/{productid}/{quantity}")]
        [Consumes("application/json")]
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
        // giving 500 error same as above
        public IActionResult ViewAllProductsAtLocationSortByID(int id)
        {
            try
            {
                List<InventoryModel> inventory = new List<InventoryModel>();
                inventory = _inventoryService.ViewAllProductsAtLocation(id);
                return Ok(inventory);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

    }
}
