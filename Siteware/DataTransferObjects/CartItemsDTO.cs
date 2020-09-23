using Siteware.Sales;
using Siteware.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siteware.Models
{
    public class CartItemsDTO
    {
        public CartItemsDTO() { }
        public CartItemsDTO(int id, int quantity, int productId, int cartId)
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

        private ISalesStrategy salesStrategy
        {
            get
            {
                switch (product.saletype)
                {
                    case SaleTypes.TAKE2PAY1:
                        return new SalesTake2Pay1();
                    case SaleTypes.TAKE3FOR10:
                        return new SalesTake3For10();
                    default:
                        return new SalesNone();
                }
            }
        }

        public double productPrice
        {
            get
            {
                return salesStrategy.caculateProductPrice(quantity, product.price);
            }
        }
    }
}
