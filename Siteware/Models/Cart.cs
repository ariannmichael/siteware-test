using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siteware.Models
{
    public class Cart
    {
        public Cart() {}
        public Cart(int id)
        {
            this.id = id;
            this.cartItems = new List<CartItems>();
        }
        public int id { get; set; }
        public ICollection<CartItems> cartItems { get; set; }
    }
}
