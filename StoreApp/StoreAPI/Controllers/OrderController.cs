using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using OrdersLib;
using StoreDB.Entities;
using StoreDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly ICartItemService _cartItemService;
        private readonly IOrdersService _ordersService;
        private readonly CartService _cartService;
        
        /// <summary>
        /// carts section
        /// </summary>
        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddCart(CartsModel carts)
        {
            try
            {
                _cartService.AddCart(carts);
                return CreatedAtAction("AddCart", carts);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteCart(CartsModel carts)
        {
            try
            {
                _cartService.DeleteCart(carts);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// cart items section
        /// </summary>
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
        
        [HttpGet("get/{id}")]
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
        public IActionResult DeleteProductInCart(int cartid, int productid, int quantity)
        {
            try
            {
                _cartItemService.DeleteProductInCart(cartid, productid, quantity);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        /// <summary>
        /// orders section
        /// </summary>
        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult PlaceOrder(OrderModel order)
        {
            try
            {
                _cartItemService.PlaceOrder(order);
                return CreatedAtAction("PlaceOrder", order);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddToOrder(LineItemModel lineItem)
        {
            try
            {
                _ordersService.AddToOrder(lineItem);
                return CreatedAtAction("AddToOrder", lineItem);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("get/{id}")]
        [Produces("application/json")]
        public IActionResult GetAllProductsInOrderByID(int id)
        {
            try
            {
                return Ok(_ordersService.GetAllProductsInOrderByID(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
