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
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> getAllCarts()
        {
            try
            {
                var results = await this.cartService.getAllCarts();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{cartId}")]
        public async Task<IActionResult> getCartById(int cartId)
        {
            try
            {
                var result = await this.cartService.getCartById(cartId);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> postCart(Cart cart)
        {
            try
            {
                Cart newCart = await this.cartService.postCart(cart);

                if (newCart != null)
                {
                    return Created($"/cart/{newCart.id}", newCart);
                }
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database error");
            }

            return BadRequest();
        }

        [HttpPut("{cartId}")]
        public async Task<IActionResult> putCart(int cartId, Cart cart)
        {
            try
            {
                Cart newCart = await this.cartService.putCart(cartId, cart);

                if (newCart == null)
                {
                    return NotFound();
                }

                return Created($"/cart/{newCart.id}", newCart);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database error");
            }

            return BadRequest();
        }

        [HttpDelete("{cartId}")]
        public async Task<IActionResult> deleteCart(int cartId)
        {
            try
            {
                Boolean result = await this.cartService.deleteCart(cartId);

                if(!result)
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
