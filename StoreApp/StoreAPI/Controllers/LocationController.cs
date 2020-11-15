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
        public IActionResult GetAllOrdersByLocationID(int id)
        {
            try
            {
                List<OrderModel> orders = _locationService.GetAllOrdersByLocationID(id);
                List<OrderModel> order = orders;
                return Ok(order);
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
        public IActionResult AddProductToLocation(InventoryModel item)
        {
            try
            {
                _locationService.AddProductToLocation(item);
                return CreatedAtAction("AddProductToLocation", item);
            }
            catch (Exception)
            {
                return BadRequest();//doing this
            }
        }

        [HttpDelete("delete/product/{locationid}/{productid}/{quantity}")]
        //500 error processing request
        public IActionResult DeleteProductAtLocation(InventoryModel item)
        {
            try
            {
                _locationService.DeleteProductAtLocation(item);
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
                List<InventoryModel> items = _locationService.GetLocationInventory(id);
                List<InventoryModel> item2 = items;
                return Ok(item2);
            }
            catch (Exception)
            {
                return NotFound(); //doing this matches shaelies but still doesnt work
            }
        }

    }
}
