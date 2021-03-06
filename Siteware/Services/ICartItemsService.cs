﻿using Siteware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siteware.Services
{
    public interface ICartItemsService
    {
        public Task<CartItems[]> getAllCartItems();
        public Task<CartItemsDTO> getCartItemById(int cartItemId);
        public Task<CartItemsDTO[]> getAllCartItemsByCartId(int cartId);
        public Task<CartItems> postCartItem(CartItems newCartItem);
        public Task<CartItems> putCartItem(int cartItemId, CartItems newCartItem);
        public Task<Boolean> deleteCartItem(int cartItemId);
    }
}
