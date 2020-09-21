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
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> getAllProducts()
        {
            try
            {
                var results = this.productService.getAllProducts();
                return Ok(results);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> getProductById(int productId)
        {
            try
            {
                var result = await this.productService.getProductById(productId);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("name")]
        public async Task<IActionResult> getProductByName([FromQuery] string name)
        {
            try
            {
                var results = await this.productService.getProductByName(name);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("price")]
        public async Task<IActionResult> getProductByPrice([FromQuery] double price)
        {
            try
            {
                var results = await this.productService.getProductByPrice(price);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> postProduct(Product newProduct)
        {
            try
            {
                Product product = await this.productService.postProduct(newProduct);
                
                if(product != null)
                {
                    return Created($"/product/{product.id}", product);
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return BadRequest();
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> putProduct(int productId, Product newProduct)
        {
            try
            {
                Product product = await this.productService.putProduct(productId, newProduct);

                if(product == null)
                {
                    return NotFound();
                }

                return Created($"/product/{newProduct.id}", newProduct);    
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> deleteProduct(int productId)
        {
            try
            {
                Boolean result = await this.productService.deleteProduct(productId);

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
