﻿using LocationLib;
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

        [HttpGet("get")]
        [Produces("application/json")]
        [Consumes("application/json")]
        //500 error
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
        //500 error
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
        [HttpGet("get/history/datedesc/{id}")]
        [Produces("application/json")]
        //giving 400 error so going to catch block
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
                return StatusCode(400); //coming here so return messed up
            }
        }
        [HttpGet("get/history/priceasc/{id}")]
        [Produces("application/json")]
        //giving 400 error so going to catch block
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
                return StatusCode(400); //coming here so return messed up
            }
        }
        [HttpGet("get/history/pricedsc/{id}")]
        [Produces("application/json")]
        //giving 400 error so going to catch block
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
                _inventoryService.AddProductToLocation(item);
                int location = item.productID;
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
                _inventoryService.DeleteProductAtLocation(item);
                int id = item.productID;
                return Ok();
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
                List<InventoryModel> items = _inventoryService.ViewAllProductsAtLocation(id);
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