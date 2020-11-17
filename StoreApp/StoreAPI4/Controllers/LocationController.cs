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
    public class LocationController : ControllerBase
    {
        /// <summary>
        /// will include location and inventory services
        /// </summary>
        private readonly LocationService _locationService;
        private readonly InventoryService _inventoryService;
        private readonly ProductServices _productService;

        public LocationController(LocationService locationService, InventoryService inventoryService, ProductServices productServices)
        {
            _locationService = locationService;
            _inventoryService = inventoryService;
            _productService = productServices;
        }

        [HttpGet("get")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public IActionResult GetAllLocations()
        {
            try
            {
                List<LocationModel> locations = _locationService.GetAllLocations();
                List<LocationModel> location = locations;
                return Ok(location);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        [HttpGet("get/{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public IActionResult GetLocationByID(int id)
        {
            try
            {
                LocationModel location = _locationService.GetLocationByID(id);
                string name = location.Name;
                return Ok(location);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        /// <summary>
        /// order history by locations
        /// </summary>
        [HttpGet("get/history/{id}")]
        [Produces("application/json")]
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
                return StatusCode(400); 
            }
        }
        [HttpGet("get/history/datedesc/{id}")]
        [Produces("application/json")]
        public IActionResult GetAllOrdersByLocationIDDateDesc(int id)
        {
            try
            {
                List<OrderModel> orders = _locationService.GetAllOrdersByLocationIDDateDescending(id);
                List<OrderModel> order = orders;
                return Ok(order);
            }
            catch (Exception)
            {
                return StatusCode(400);
            }
        }
        [HttpGet("get/history/priceasc/{id}")]
        [Produces("application/json")]
        public IActionResult GetAllOrdersByLocationIDPriceAsc(int id)
        {
            try
            {
                List<OrderModel> orders = _locationService.GetAllOrdersByLocationIDPriceAscending(id);
                List<OrderModel> order = orders;
                return Ok(order);
            }
            catch (Exception)
            {
                return StatusCode(400); 
            }
        }
        [HttpGet("get/history/pricedsc/{id}")]
        [Produces("application/json")]
        public IActionResult GetAllOrdersByLocationIDPriceDesc(int id)
        {
            try
            {
                List<OrderModel> orders = _locationService.GetAllOrdersByLocationIDPriceDescending(id);
                List<OrderModel> order = orders;
                return Ok(order);
            }
            catch (Exception)
            {
                return StatusCode(400); 
            }
        }
        /// <summary>
        /// manager modifying inventory
        /// </summary>
        [HttpPost("add/product/{item}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public IActionResult AddProductToLocation(InventoryModel inventory)
        {
            try
            {
                ProductModel newItem = new ProductModel();
                newItem = _productService.GetProductByID(inventory.productID);
                InventoryModel iitem = new InventoryModel()
                {
                    productID = newItem.ID,
                    locationID = inventory.locationID,
                    Quantity = inventory.Quantity
                };
                _inventoryService.AddProductToLocation(iitem);
                return CreatedAtAction("AddProductToLocation", inventory);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete/product")]
        public IActionResult DeleteProductAtLocation(InventoryModel item)
        {
            try
            {
                ProductModel product = new ProductModel();
                product = _productService.GetProductByID(item.productID);
                InventoryModel items = new InventoryModel()
                {
                    productID = item.productID,
                    locationID = item.locationID,
                    Quantity = item.Quantity
                };
                _inventoryService.DeleteProductAtLocation(item);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// shows manager current inventory at location
        /// </summary>

        [HttpGet("get/inventory/lh/{id}")]
        [Produces("application/json")]
        public IActionResult ViewAllProductsAtLocationPriceLowToHigh(int id)
        {
            try
            {
                List<ProductModel> items = _productService.ViewAllProductsAtLocationSortByIDPriceLowToHigh(id);
                List<ProductModel> item2 = items;
                return Ok(item2);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpGet("get/inventory/hl/{id}")]
        [Produces("application/json")]
        public IActionResult ViewAllProductsAtLocationPriceHighToLow(int id)
        {
            try
            {
                List<ProductModel> items = _productService.ViewAllProductsAtLocationSortByIDPriceHighToLow(id);
                List<ProductModel> item2 = items;
                return Ok(item2);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

    }
}
