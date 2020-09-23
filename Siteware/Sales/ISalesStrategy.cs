using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siteware.Services
{
    interface ISalesStrategy
    {
        public double caculateProductPrice(int quantity, double price);
    }
}
