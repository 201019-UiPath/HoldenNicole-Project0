using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OrdersLib;
using StoreDB.Models;
using System;

namespace StoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors("_allowed")]
    public class OrderController : Controller
    {
        private readonly ICartItemService _cartItemService;
        private readonly IOrdersService _ordersService;
        private readonly ICartService _cartService;

        public OrderController(ICartItemService cartItemService, IOrdersService ordersService, ICartService cartService)
        {
            _cartItemService = cartItemService;
            _ordersService = ordersService;
            _cartService = cartService;
        }

        /// <summary>
        /// carts section
        /// </summary>
        [HttpPost("add/cart")]
        [Consumes("application/json")]
        // 415 error service unresolved again
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

        [HttpDelete("delete/cart")]
        [Consumes("application/json")]
        [Produces("application/json")]
        // 415 error same
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
        [HttpPost("add/product/{cartid}/{productid}/{quantity}")]
        [Consumes("application/json")]
        // 400 bad request error
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

        [HttpGet("getProduct/{id}")]
        [Produces("application/json")]
        // 500 error occured while processing request
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

        [HttpDelete("delete/product/{cartid}/{productid}/{quantity}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        //500 error occured while processing request
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
        [HttpPost("add/order")]
        [Produces("application/json")]
        //415 unsupported media type
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

        [HttpPatch("add/item")]
        [Consumes("application/json")]
        [Produces("application/json")]
        // 400 error one or more validation errors occured
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

        [HttpGet("getProducts/{id}")]
        [Produces("application/json")]
        //404 error
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
