using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Siteware.Data;
using Siteware.Models;

namespace Siteware.Tests.Mocks
{
    class MockContext : IRepository
    {
        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<Cart[]> GetAllCartAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CartItems[]> GetAllCartItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CartItems[]> GetAllCartItemsAsyncByCart(int cartId)
        {
            throw new NotImplementedException();
        }

        public Task<CartItems> GetAllCartItemsAsyncById(int cartItemId)
        {
            throw new NotImplementedException();
        }

        public Task<Product[]> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product[]> GetAllProductsByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Product[]> GetAllProductsByPrice(double price)
        {
            throw new NotImplementedException();
        }

        public Task<Cart> GetCartAsyncById(int cartId)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductAsyncById(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
