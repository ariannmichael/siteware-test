using Siteware.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siteware.Sales
{
    public class SalesNone : ISalesStrategy
    {
        public double caculateProductPrice(int quantity, double price)
        {
            return quantity * price;
        }
    }
}
