using AutoMapper;
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
        private readonly IMapper mapper;

        public CartItemsService(IRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public async Task<CartItems[]> getAllCartItems()
        {
            CartItems[] cartItems = await this.repo.GetAllCartItemsAsync();
            return cartItems;
        }

        public async Task<CartItemsDTO> getCartItemById(int cartItemId)
        {
            CartItems result = await this.repo.GetCartItemsAsyncById(cartItemId);
            CartItemsDTO cartItem = this.mapper.Map<CartItemsDTO>(result);

            return cartItem;
        }

        public async Task<CartItemsDTO[]> getAllCartItemsByCartId(int cartId)
        {
            CartItems[] results = await this.repo.GetAllCartItemsAsyncByCart(cartId);
            var cartItems = this.mapper.Map<CartItems[], CartItemsDTO[]>(results.ToArray());

            return cartItems;
        }

        public async Task<CartItems> postCartItem(CartItems newCartItem)
        {
            CartItems cartItem = await this.repo.GetCartItemsAsyncByProductAndCart(newCartItem.cartId, newCartItem.productId);

            if(cartItem != null)
            {
                cartItem.quantity += 1;
                this.repo.Update<CartItems>(cartItem);
            } else
            {
                this.repo.Add<CartItems>(newCartItem);
            }

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

