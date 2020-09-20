using Microsoft.EntityFrameworkCore;
using Siteware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siteware.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartItems> CartItems { get; set; }
        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var products = new List<Product>()
                {
                    new Product(1, "Fender Jazzmaster", 230.00, SaleTypes.TAKE2PAY1),
                    new Product(2, "Fender Stratocaster", 150.00, SaleTypes.TAKE2PAY1),
                    new Product(3, "Ibanez JEM", 400.00, SaleTypes.TAKE3FOR10),
                    new Product(4, "Gibson SG", 250.00),
                    new Product(5, "Gibson Explorer", 500.00)
                };

            var carts = new List<Cart>()
                {
                    new Cart(1)
                };

            var cartItems = new List<CartItems>()
                {
                    new CartItems(1, 1, 2, 1),
                    new CartItems(2, 2, 4, 1),
                    new CartItems(3, 3, 3, 1),
                    new CartItems(4, 5, 1, 1)
                };


            modelBuilder.Entity<Product>().HasData(products);
            modelBuilder.Entity<Cart>().HasData(carts);
            modelBuilder.Entity<CartItems>().HasData(cartItems);    
        }
    }
}
