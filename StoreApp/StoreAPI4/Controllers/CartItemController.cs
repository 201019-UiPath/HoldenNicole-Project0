using CustomerLib;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OrdersLib;
using StoreDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI4.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors("_allowed")]
    public class CartItemController : Controller
    {
        private readonly ICartItemService cartItemService;
        private readonly ICustomerService customerService;

        public CartItemController(ICartItemService cartItemService, ICustomerService customerService)
        {
            this.cartItemService = cartItemService;
            this.customerService = customerService;
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddToCart(CartItemModel cartItem)
        {
            try
            {
                cartItemService.AddProductToCart(cartItem);
                return CreatedAtAction("AddToCart", cartItem);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteCartItem(CartItemModel cartItem)
        {
            try
            {
                cartItemService.DeleteProductInCart(cartItem);
                int id = cartItem.id;
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet("get/{cartid}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public IActionResult GetAllCartItems(int cartid)
        {
            try
            {
                List<CartItemModel> items = cartItemService.GetAllProductsInCartByCartID(cartid);
                List<CartItemModel> item = items;
                return Ok(items);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
