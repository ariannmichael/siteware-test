using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Siteware.Data;
using Siteware.Models;
using Siteware.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siteware.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartItemsController : ControllerBase
    {
        private readonly ICartItemsService cartItemsService;

        public CartItemsController(ICartItemsService cartItemsService)
        {
            this.cartItemsService = cartItemsService;
        }

        [HttpGet]
        public async Task<IActionResult> getAllCartItems()
        {
            try
            {
                var results = await this.cartItemsService.getAllCartItems();
                return Ok(results);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database error");
            }
        }

        [HttpGet("{cartItemId}")]
        public async Task<IActionResult> getCartItemById(int cartItemId)
        {
            try
            {
                var result = await this.cartItemsService.getCartItemById(cartItemId);
                return Ok(result);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database error");
            }
        }

        [HttpGet("cart")]
        public async Task<IActionResult> getAllCartItemsByCartId([FromQuery] int cartId)
        {
            try
            {
                var results = await this.cartItemsService.getAllCartItemsByCartId(cartId);
                return Ok(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> postCartItem(CartItems newCartItem)
        {
            try
            {
                CartItems cartItems = await this.cartItemsService.postCartItem(newCartItem);

                if (cartItems != null)
                {
                    return Created($"/cartItems/{newCartItem.id}", newCartItem);
                }
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database error");
            }

            return BadRequest();
        }

        [HttpPut("{cartItemId}")]
        public async Task<IActionResult> putCartItem(int cartItemId, CartItems newCartItem)
        {
            try
            {
                CartItems cartItem = await this.cartItemsService.putCartItem(cartItemId, newCartItem);

                if (cartItem == null)
                {
                    return NotFound();
                }
              
                return Created($"/cartItems/{newCartItem.id}", newCartItem);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database error");
            }
        }

        [HttpDelete("{cartItemId}")]
        public async Task<IActionResult> deleteCartItem(int cartItemId)
        {
            try
            {
                Boolean result = await this.cartItemsService.deleteCartItem(cartItemId);

                if (!result)
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database error");
            }
        }
    }
}
