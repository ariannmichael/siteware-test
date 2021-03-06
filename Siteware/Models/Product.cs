﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Siteware.Models
{
    public class Product
    {
        public Product() {}
        public Product(int id, string name, double price, SaleTypes saleType = SaleTypes.NONE)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.saletype = saleType;
        }

        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        [EnumDataType(typeof(SaleTypes))]
        public SaleTypes saletype { get; set; }
    }
}
