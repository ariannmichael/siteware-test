using Siteware.Data;
using Siteware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siteware.Services
{
    public class CartItemsService : ICartItemsService
    {
        private readonly IRepository repo;

        public CartItemsService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<CartItems[]> getAllCartItems()
        {
            CartItems[] results = await this.repo.GetAllCartItemsAsync();
            return results;
        }

        public async Task<CartItems> getCartItemById(int cartItemId)
        {
            CartItems result = await this.repo.GetCartItemsAsyncById(cartItemId);
            return result;
        }

        public async Task<CartItems[]> getAllCartItemsByCartId(int cartId)
        {
            CartItems[] results = await this.repo.GetAllCartItemsAsyncByCart(cartId);
            return results;
        }

        public async Task<CartItems> postCartItem(CartItems newCartItem)
        {

            this.repo.Add<CartItems>(newCartItem);

            if (await this.repo.SaveChangesAsync())
            {
                return newCartItem;
            }

            return null;
        }

        public async Task<CartItems> putCartItem(int cartItemId, CartItems newCartItem)
        {
            CartItems cartItem = await this.repo.GetCartItemsAsyncById(cartItemId);

            if (cartItem != null)
            {                
                this.repo.Update<CartItems>(newCartItem);

                if (await this.repo.SaveChangesAsync())
                {
                    return newCartItem;
                }
            }

            return null;
        }

        public async Task<Boolean> deleteCartItem(int cartItemId)
        {
            CartItems cartItem = await this.repo.GetCartItemsAsyncById(cartItemId);

            if (cartItem != null)
            {
                this.repo.Delete<CartItems>(cartItem);

                if (await this.repo.SaveChangesAsync())
                {
                    return true;
                }
            }

            return false;
        }
    }
}

