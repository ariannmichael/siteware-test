using Siteware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siteware.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        // Products
        Task<Product[]> GetAllProductsAsync();
        Task<Product> GetProductAsyncById(int productId);
        Task<Product[]> GetAllProductsByName(string name);
        Task<Product[]> GetAllProductsByPrice(double price);

        // Cart
        Task<Cart[]> GetAllCartAsync();
        Task<Cart> GetCartAsyncById(int cartId);

        // CartItems
        Task<CartItems[]> GetAllCartItemsAsync();
        Task<CartItems> GetCartItemsAsyncById(int cartItemId);
        Task<CartItems[]> GetAllCartItemsAsyncByCart(int cartId);
        Task<CartItems> GetCartItemsAsyncByProductAndCart(int cartId, int productId);
    }
}
