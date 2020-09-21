using Siteware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siteware.Services
{
    public interface ICartService
    {
        public Task<Cart[]> getAllCarts();
        public Task<Cart> getCartById(int cartId);
        public Task<Cart> postCart(Cart newCart);
        public Task<Cart> putCart(int cartId, Cart newCart);
        public Task<Boolean> deleteCart(int cartId);
    }
}
