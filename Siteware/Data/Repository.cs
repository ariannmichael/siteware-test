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
            IQueryable<Product> query = this.context.Products.AsNoTracking();
            return await query.ToArrayAsync();
        }

        public async Task<Product> GetProductAsyncById(int productId)
        {
            IQueryable<Product> query = this.context.Products
                .AsNoTracking()
                .Where(p => p.id == productId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Product[]> GetAllProductsByName(string name)
        {
            IQueryable<Product> query = this.context.Products
                .Where(p => p.name.ToLower().Contains(name.ToLower()))
                .AsNoTracking();

            return await query.ToArrayAsync();
        }

        public async Task<Product[]> GetAllProductsByPrice(double price)
        {
            IQueryable<Product> query = this.context.Products
                .Where(p => p.price == price)
                .AsNoTracking();

            return await query.ToArrayAsync();
        }

        // Carts
        public async Task<Cart[]> GetAllCartAsync()
        {
            IQueryable<Cart> query = this.context.Carts
                .AsNoTracking();
            return await query.ToArrayAsync();
        }

        public async Task<Cart> GetCartAsyncById(int cartId)
        {
            IQueryable<Cart> query = this.context.Carts
                .Where(c => c.id == cartId)
                .Include(c => c.cartItems)
                .AsNoTracking();

            return await query.FirstOrDefaultAsync();
        }

        // CartItems
        public async Task<CartItems[]> GetAllCartItemsAsync()
        {
            IQueryable<CartItems> query = this.context.CartItems
                .Include(ci => ci.product)
                .AsNoTracking();

            return await query.ToArrayAsync();
        }
        public async Task<CartItems[]> GetAllCartItemsAsyncByCartId(int cartId)
        {
            IQueryable<CartItems> query = this.context.CartItems
                .Where(ci => ci.cartId == cartId)
                .Include(ci => ci.product)
                .AsNoTracking();

            return await query.ToArrayAsync();
        }

        public async Task<CartItems> GetCartItemsAsyncById(int cartItemId)
        {
            IQueryable<CartItems> query = this.context.CartItems
                .Where(ci => ci.id == cartItemId)
                .Include(ci => ci.product)
                .AsNoTracking();

            return await query.FirstOrDefaultAsync();
        }

        public async Task<CartItems> GetCartItemsAsyncByProductAndCart(int cartId, int productId)
        {
            IQueryable<CartItems> query = this.context.CartItems
                .Where(ci => ci.cartId == cartId)
                .Where(ci => ci.productId == productId)
                .Include(ci => ci.product)
                .AsNoTracking();

            return await query.FirstOrDefaultAsync();
        }
    }
}
