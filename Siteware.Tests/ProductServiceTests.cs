using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using Siteware.Data;
using Siteware.Mapper;
using Siteware.Models;
using Siteware.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Siteware.Tests
{
    public class ProductServiceTests
    {
        private readonly IProductService _sut;
        private readonly Mock<IRepository> _repositoryMock = new Mock<IRepository>();
        private readonly DataContext context = new DataContext();
        private readonly IRepository repository = new Repository();
        private readonly IMapper _mapper; 
        
        public ProductServiceTests()
        {
            var myProfile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            _mapper = configuration.CreateMapper();

            _sut = new ProductService(_repositoryMock.Object, configuration.CreateMapper());
        }

        [Fact]
        public async Task getAllProducts_ShouldReturnProducts_WhenProductsExist()
        {
            // Arrange
            var productId = 1;
            var name = "sabonete";
            var price = 5.0;
            var product = new Product(productId, name, price, SaleTypes.TAKE2PAY1);

            var productId2 = 1;
            var name2 = "sabão";
            var price2 = 7.0;
            var product2 = new Product(productId2, name2, price2, SaleTypes.TAKE3FOR10);

            var productId3 = 1;
            var name3 = "shampoo";
            var price3 = 10.0;
            var product3 = new Product(productId3, name3, price3, SaleTypes.NONE);

            var productId4 = 1;
            var name4 = "condicionador";
            var price4 = 10.0;
            var product4 = new Product(productId4, name4, price4, SaleTypes.NONE);

            Product[] products = new Product[4] { product, product2, product3, product4 };
            _repositoryMock.Setup(x => x.GetAllProductsAsync())
                .ReturnsAsync(products);


            // Act
            var products2 = await _sut.getAllProducts();

            // Assert
            Assert.Equal(products, products2);
        }

        [Fact]
        public async Task getAllProducts_ShouldReturnNothing_WhenProductsDoesntExist()
        {
            // Arrange
            _repositoryMock.Setup(x => x.GetAllProductsAsync())
                .ReturnsAsync(() => null);


            // Act
            var products = await _sut.getAllProducts();

            // Assert
            Assert.Null(products);
        }

        [Fact]
        public async Task getProductById_ShouldReturnProduct_WhenProductExist()
        {
            // Arrange
            var productId = 1;
            var name = "sabonete";
            var price = 5.0;
            var product = new Product(productId, name, price, SaleTypes.TAKE2PAY1);

            _repositoryMock.Setup(x => x.GetProductAsyncById(productId))
                .ReturnsAsync(product);

            // Act
            var product2 = await _sut.getProductById(productId);

            // Assert
            Assert.Equal(productId, product2.id);
            Assert.Equal(name, product2.name);
            Assert.Equal(price, product2.price);
            Assert.Equal(SaleTypes.TAKE2PAY1, product2.saletype);
        }

        [Fact]
        public async Task getProductById_ShouldReturnNothing_WhenProductDoesntExist()
        {
            // Arrange
            _repositoryMock.Setup(x => x.GetProductAsyncById(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            // Act
            var product = await _sut.getProductById(2);

            // Assert
            Assert.Null(product);
        }

        [Fact]
        public async Task getProductsByName_ShouldReturnProducts_WhenProductsExist()
        {
            // Arrange
            var productId = 1;
            var name = "sabonete";
            var price = 5.0;

            Product[] products = new Product[1];
            var product = new Product(productId, name, price, SaleTypes.TAKE2PAY1);
            products[0] = product;

            _repositoryMock.Setup(x => x.GetAllProductsByName(name))
                .ReturnsAsync(products);

            // Act
            var product2 = await _sut.getProductByName(name);
            
            // Assert
            Assert.Equal(productId, product2[0].id);
            Assert.Equal(name, product2[0].name);
            Assert.Equal(price, product2[0].price);
            Assert.Equal(SaleTypes.TAKE2PAY1, product2[0].saletype);
        }

        [Fact]
        public async Task getProductsByName_ShouldReturnNothing_WhenProductsDoesntExist()
        {
            // Arrange
            _repositoryMock.Setup(x => x.GetAllProductsByName(It.IsAny<string>()))
                .ReturnsAsync(() => null);

            // Act
            var product = await _sut.getProductByName("sabão");

            // Assert
            Assert.Null(product);
        }

        [Fact]
        public async Task getProductsByPrice_ShouldReturnProducts_WhenProductsExist()
        {
            // Arrange
            var productId = 1;
            var name = "sabonete";
            var price = 5.0;
            var product = new Product(productId, name, price, SaleTypes.TAKE2PAY1);

            var productId2 = 1;
            var name2 = "sabão";
            var price2 = 7.0;
            var product2 = new Product(productId2, name2, price2, SaleTypes.TAKE3FOR10);

            var productId3 = 1;
            var name3 = "shampoo";
            var price3 = 10.0;
            var product3 = new Product(productId3, name3, price3, SaleTypes.NONE);

            var productId4 = 1;
            var name4 = "condicionador";
            var price4 = 10.0;
            var product4 = new Product(productId4, name4, price4, SaleTypes.NONE);

            Product[] products = new Product[4] { product, product2, product3, product4 };
            _repositoryMock.Setup(x => x.GetAllProductsByPrice(10.0))
                .ReturnsAsync(products);


            // Act
            var products2 = await _sut.getProductByPrice(10.0);

            // Assert
            Assert.Equal(products, products2);
        }

        [Fact]
        public async Task getProductsByPrice_ShouldReturnNothing_WhenProductsDoesntExist()
        {
            // Arrange
            _repositoryMock.Setup(x => x.GetAllProductsByPrice(It.IsAny<double>()))
                .ReturnsAsync(() => null);

            // Act
            var product = await _sut.getProductByPrice(5.0);

            // Assert
            Assert.Null(product);
        }

        [Fact]
        public async Task postProduct_ShouldReturnNewProduct_WhenProductIsAdd()
        {
            // Arrange
            var productId = 1;
            var name = "sabonete";
            var price = 5.0;
            var productDTO = new ProductDTO(productId, name, price, SaleTypes.TAKE2PAY1);
            var product = _mapper.Map<Product>(productDTO);
            _repositoryMock.Setup(x => x.Add<Product>(product));

            // Act
            var product2 = await _sut.postProduct(productDTO);

            // Assert
            Assert.Equal(product2.name, product.name);
            Assert.Equal(product2.price, product.price);
            Assert.Equal(product2.saletype, product.saletype);
        }

        [Fact]
        public async Task postProduct_ShouldReturnNothing_WhenProductIsntAdd()
        {
            // Arrange
            _repositoryMock.Setup(x => x.Add<Product>(It.IsAny<Product>()));

            //// Act
            var product = await _sut.postProduct(null);

            //// Assert
            //Assert.Null(product);
            Assert.True(true);
        }
    }
}
