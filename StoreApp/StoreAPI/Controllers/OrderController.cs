using Microsoft.AspNetCore.Mvc;
using OrdersLib;
using StoreDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Controllers
{
    [Route("[controller")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly ICartItemService _cartItemService;
        private readonly IOrdersService _ordersService;

        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddProductToCart(int cartid, int productid, int quantity)
        {
            try
            {
                _cartItemService.AddProductToCart(cartid, productid, quantity);
                return CreatedAtAction("AddProductToCart", (cartid, productid, quantity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        
        [HttpGet("get")]
        [Produces("application/json")]
        public IActionResult GetAllProductsInCartByCartID(int id)
        {
            try
            {
                return Ok(_cartItemService.GetAllProductsInCartByCartID(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteProductFromCart(int cartid, int productid)
        {
            try
            {
                return Ok(_cartItemService.DeleteProductInCart(cartid, productid));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
