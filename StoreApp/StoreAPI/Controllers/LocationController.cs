using LocationLib;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LocationController : Controller
    {
        /// <summary>
        /// will include location and inventory services
        /// </summary>
        /// <returns></returns>
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
        [EnableCors("_allowed")]
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

    /*    [HttpGet("get/{id}")]
        [Produces("application/json")]
        public IActionResult GetAllOrdersByLocationIDDateDescending(int id)
        {
            try
            {
                return Ok(_locationService.GetAllOrdersByLocationIDDateDescending(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/{id}")]
        [Produces("application/json")]
        public IActionResult GetAllOrdersByLocationIDPriceAscending(int id)
        {
            try
            {
                return Ok(_locationService.GetAllOrdersByLocationIDPriceAscending(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/{id}")]
        [Produces("application/json")]
        public IActionResult GetAllOrdersByLocationIDPriceDescending(int id)
        {
            try
            {
                return Ok(_locationService.GetAllOrdersByLocationIDPriceDescending(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        } */

        /// <summary>
        /// manager modifying inventory
        /// </summary>
        /// <returns></returns>
        [HttpPost("add/product")]
        [Consumes("application/json")]
        [Produces("application/json")]
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

        [HttpDelete("delete/product")]
        [Consumes("application/json")]
        [Produces("application/json")]
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
        [EnableCors("_allowed")]
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

    /*    [HttpGet("get/{id}")]
        [Produces("application/json")]
        public IActionResult ViewAllProductsAtLocationSortByQuantityAscending(int id)
        {
            try
            {
                return Ok(_inventoryService.ViewAllProductsAtLocationSortByQuantityAscending(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/{id}")]
        [Produces("application/json")]
        public IActionResult ViewAllProductsAtLocationSortByQuantityDescending(int id)
        {
            try
            {
                return Ok(_inventoryService.ViewAllProductsAtLocationSortByQuantityDescending(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get")]
        [Produces("application/json")]
        public IActionResult GetAllLocations()
        {
            try
            {
                return Ok(_locationService.GetAllLocations());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        } */
    } 
}
