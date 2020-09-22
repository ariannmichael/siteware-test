using Siteware.Data;
using Siteware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siteware.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository repo;

        public ProductService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<Product[]> getAllProducts()
        {
            Product[] results = await this.repo.GetAllProductsAsync();
            return results;
        }
        public async Task<Product> getProductById(int productId)
        {
            Product result = await this.repo.GetProductAsyncById(productId);
            return result;
        }

        public async Task<Product[]> getProductByName(string name)
        {
            Product[] results = await this.repo.GetAllProductsByName(name);
            return results;
        }

        public async Task<Product[]> getProductByPrice(double price)
        {
            Product[] results = await this.repo.GetAllProductsByPrice(price);
            return results;
        }

        public async Task<Product> postProduct(ProductDTO newProduct)
        {
            this.repo.Add<Product>(newProduct);

            if (await this.repo.SaveChangesAsync())
            {
                return newProduct;
            } else
            {
                return null;
            }
        }

        public async Task<Product> putProduct(int productId, Product newProduct)
        {

            Product product = await this.repo.GetProductAsyncById(productId);

            if (product != null)
            {
                this.repo.Update<Product>(newProduct);

                if (await this.repo.SaveChangesAsync())
                {
                    return newProduct;
                }
            }

            return null;
        }

        public async Task<Boolean> deleteProduct(int productId)
        {
            var product = await this.repo.GetProductAsyncById(productId);

            if (product != null)
            {
                this.repo.Delete<Product>(product);

                if (await this.repo.SaveChangesAsync())
                {
                    return true;
                }
            }

            return false;
        }
    }
}

