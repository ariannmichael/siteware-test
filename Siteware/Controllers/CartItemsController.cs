using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{cartItemId}")]
        public async Task<IActionResult> getCartItemById(int cartItemId)
        {
            try
            {
                var cartItem = await this.cartItemsService.getCartItemById(cartItemId);
                return Ok(cartItem);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
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
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> postCartItem(CartItems cartItems)
        {
            try
            {
                CartItems newCartItems = await this.cartItemsService.postCartItem(cartItems);

                if (newCartItems != null)
                {
                    return Ok(newCartItems);
                }
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return BadRequest();
        }

        [HttpPut("{cartItemId}")]
        public async Task<IActionResult> putCartItem(int cartItemId, CartItems cartItem)
        {
            try
            {
                CartItems newCartItem = await this.cartItemsService.putCartItem(cartItemId, cartItem);

                if (newCartItem == null)
                {
                    return NotFound();
                }
              
                return Created($"/cartItems/{newCartItem.id}", newCartItem);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
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
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
