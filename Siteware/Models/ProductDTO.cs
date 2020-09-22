using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Siteware.Models
{
    public class ProductDTO
    {
        public ProductDTO() { }
        public ProductDTO(int id, string name, double price, SaleTypes saleType = SaleTypes.NONE)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.saletype = saleType;
        }

        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public double price { get; set; }
        [EnumDataType(typeof(SaleTypes))]
        public SaleTypes saletype { get; set; }
    }
}
