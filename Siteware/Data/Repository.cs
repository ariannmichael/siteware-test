using Microsoft.EntityFrameworkCore;
using Siteware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siteware.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext context;

        public Repository(DataContext context)
        {
            this.context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            this.context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            this.context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            this.context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await this.context.SaveChangesAsync()) > 0;
        }

        // Products
        public async Task<Product[]> GetAllProductsAsync()
        {
            IQueryable<Product> query = this.context.Products;
            return await query.ToArrayAsync();
        }

        public async Task<Product> GetProductAsyncById(int productId)
        {
            IQueryable<Product> query = this.context.Products
                .Where(p => p.id == productId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Product[]> GetAllProductsByName(string name)
        {
            IQueryable<Product> query = this.context.Products
                .Where(p => p.name.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Product[]> GetAllProductsByPrice(double price)
        {
            IQueryable<Product> query = this.context.Products
                .Where(p => p.price == price);

            return await query.ToArrayAsync();
        }

        // Carts
        public async Task<Cart[]> GetAllCartAsync()
        {
            IQueryable<Cart> query = this.context.Carts;
            return await query.ToArrayAsync();
        }

        public async Task<Cart> GetCartAsyncById(int cartId)
        {
            IQueryable<Cart> query = this.context.Carts
                .Where(c => c.id == cartId);

            return await query.FirstOrDefaultAsync();
        }

        // CartItems
        public async Task<CartItems[]> GetAllCartItemsAsync()
        {
            IQueryable<CartItems> query = this.context.CartItems
                .Include(ci => ci.cartId)
                .Include(ci => ci.product);

            return await query.ToArrayAsync();
        }
        public async Task<CartItems[]> GetAllCartItemsAsyncByCart(int cartId)
        {
            IQueryable<CartItems> query = this.context.CartItems
                .Include(ci => ci.cartId)
                .Where(ci => ci.cartId == cartId);

            return await query.ToArrayAsync();
        }

        public async Task<CartItems> GetAllCartItemsAsyncById(int cartItemId)
        {
            IQueryable<CartItems> query = this.context.CartItems
                .Where(ci => ci.id == cartItemId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
