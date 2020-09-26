using AutoMapper;
using Moq;
using Siteware.Data;
using Siteware.Mapper;
using Siteware.Models;
using Siteware.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Siteware.Tests
{
    public class CartServiceTests
    {
        private readonly ICartService _sut;
        private readonly Mock<IRepository> _repositoryMock = new Mock<IRepository>();

        public CartServiceTests()
        {
            _sut = new CartService(_repositoryMock.Object);
        }

        [Fact]
        public async Task getAllCarts_ShouldReturnCarts_WhenCartsExist()
        {
            // Arrange
            var cart1 = new Cart(1);
            var cart2 = new Cart(2);
            var cart3 = new Cart(3);
            var cart4 = new Cart(4);

            Cart[] carts = new Cart[4] { cart1, cart2, cart3, cart4 };
            _repositoryMock.Setup(x => x.GetAllCartAsync())
                .ReturnsAsync(carts);


            // Act
            var carts2 = await _sut.getAllCarts();

            // Assert
            Assert.Equal(carts, carts2);
        }

        [Fact]
        public async Task getAllCarts_ShouldReturnNothing_WhenCartsDoesntExist()
        {
            // Arrange
            _repositoryMock.Setup(x => x.GetAllCartAsync())
                .ReturnsAsync(() => null);


            // Act
            var carts = await _sut.getAllCarts();

            // Assert
            Assert.Null(carts);
        }

        [Fact]
        public async Task getCartById_ShouldReturnCart_WhenCartExist()
        {
            // Arrange
            var cart1 = new Cart(1);

            _repositoryMock.Setup(x => x.GetCartAsyncById(1))
                .ReturnsAsync(cart1);


            // Act
            var cart2 = await _sut.getCartById(1);

            // Assert
            Assert.Equal(cart1, cart2);
        }

        [Fact]
        public async Task getCartById_ShouldReturnNothing_WhenCartDoesntExist()
        {
            // Arrange
            _repositoryMock.Setup(x => x.GetCartAsyncById(It.IsAny<int>()))
                .ReturnsAsync(() => null);


            // Act
            var products = await _sut.getCartById(1);

            // Assert
            Assert.Null(products);
        }
    }
}
