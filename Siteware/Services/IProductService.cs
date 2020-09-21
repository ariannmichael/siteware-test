using Siteware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siteware.Services
{
    public interface IProductService
    {
        public Task<Product[]> getAllProducts();
        public Task<Product> getProductById(int productId);
        public Task<Product[]> getProductByName(string name);
        public Task<Product[]> getProductByPrice(double price);
        public Task<Product> postProduct(Product newProduct);
        public Task<Product> putProduct(int productId, Product newProduct);
        public Task<Boolean> deleteProduct(int productId);
    }
}
