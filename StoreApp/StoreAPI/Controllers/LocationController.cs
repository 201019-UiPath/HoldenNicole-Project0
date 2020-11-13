using LocationLib;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;

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
        //giving 500 error
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
        [Produces("application/json")]
        //405 error
        public IActionResult AddProductToLocation(int locationid, int productid, int quantity)
        {
            try
            {
                _locationService.AddProductToLocation(locationid, productid, quantity);
                return CreatedAtAction("AddProductToLocation", (locationid, productid, quantity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete/product/{locationid}/{productid}/{quantity}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        //405 error
        public IActionResult DeleteProductAtLocation(int locationid, int productid, int quantity)
        {
            try
            {
                _locationService.DeleteProductAtLocation(locationid, productid, quantity);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// shows manager current inventory at location
        /// </summary>

        [HttpGet("get/inventory/{id}")]
        [Produces("application/json")]
        // giving 500 error
        public IActionResult ViewAllProductsAtLocationSortByID(int id)
        {
            try
            {
                return Ok(_inventoryService.ViewAllProductsAtLocationSortByID(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

    }
}
