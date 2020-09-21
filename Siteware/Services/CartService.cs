using Siteware.Data;
using Siteware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siteware.Services
{
    public class CartService : ICartService
    {
        private readonly IRepository repo;

        public CartService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<Cart[]> getAllCarts()
        {
            Cart[] results = await this.repo.GetAllCartAsync();
            return results;
        }

        public async Task<Cart> getCartById(int cartId)
        {
            Cart result = await this.repo.GetCartAsyncById(cartId);
            return result;
        }

        public async Task<Cart> postCart(Cart newCart)
        {
            this.repo.Add<Cart>(newCart);

            if (await this.repo.SaveChangesAsync())
            {
                return newCart;
            } else
            {
                return null;
            }
        }

        public async Task<Cart> putCart(int cartId, Cart newCart)
        {
            Cart cart = await this.repo.GetCartAsyncById(cartId);

            if (cart != null)
            {
                this.repo.Update<Cart>(newCart);

                if (await this.repo.SaveChangesAsync())
                {
                    return newCart;
                }
            }

            return null;
        }

        public async Task<Boolean> deleteCart(int cartId)
        {
            var cart = await this.repo.GetCartAsyncById(cartId);

            if (cart != null)
            {
                this.repo.Delete<Cart>(cart);

                if (await this.repo.SaveChangesAsync())
                {
                    return true;
                } 
            }

            return false;
        }
    }
}
