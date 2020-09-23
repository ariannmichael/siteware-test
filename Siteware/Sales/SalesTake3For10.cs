using Siteware.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siteware.Sales
{
    public class SalesTake3For10 : ISalesStrategy
    {
        public double caculateProductPrice(int quantity, double price)
        {
            return 10.0 * (quantity / 3);
        }
    }
}
