﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreDB.Models;
using OrdersLib;

namespace StoreAPI4.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors("_allowed")]
    public class OrderController : Controller
    {
        private readonly IOrdersService orderService;
        
        public OrderController(IOrdersService orderService)
        {
            this.orderService = orderService;
        }
        [HttpPost("place/order")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult PlaceOrder(OrderModel order)
        {
            try
            {
                orderService.PlaceOrder(order);
                int test = order.CustomerID;
                return CreatedAtAction("PlaceOrder", order);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}