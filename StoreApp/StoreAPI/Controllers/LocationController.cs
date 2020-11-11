using LocationLib;
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

        /// <summary>
        /// order history by locations
        /// </summary>
        [HttpGet("get")]
        [Produces("application/json")]
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

        [HttpGet("get")]
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

        [HttpGet("get")]
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

        [HttpGet("get")]
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
        }

        /// <summary>
        /// manager modifying inventory
        /// </summary>
        /// <returns></returns>
        [HttpPost("add")]
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

        [HttpDelete("delete")]
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
        
        [HttpGet("get")]
        [Produces("application/json")]
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

        [HttpGet("get")]
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

        [HttpGet("get")]
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
    }
}
