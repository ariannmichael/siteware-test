using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siteware.Models
{
    public class CartItems
    {
        public CartItems() {}
        public CartItems(int id, int quantity, int productId, int cartId)
        {
            this.id = id;
            this.quantity = quantity;
            this.productId = productId;
            this.cartId = cartId;
        }

        public int id { get; set; }
        public int quantity { get; set; }
        public int cartId { get; set; }
        public Cart cart { get; set; }
        public int productId { get; set; }
        public Product product { get; set; }
    }
}
