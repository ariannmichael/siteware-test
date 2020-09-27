using Siteware.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siteware.Sales
{
    public class SalesTake2Pay1 : ISalesStrategy
    {
        public double caculateProductPrice(int quantity, double price)
        {
            return (price*quantity)/2.0;
        }
    }
}
