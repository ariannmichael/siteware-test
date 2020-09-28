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
    public class CartItemsTests
    {
        private readonly ICartItemsService _sut;
        private readonly Mock<IRepository> _repositoryMock = new Mock<IRepository>();
        private readonly IMapper _mapper;

        public CartItemsTests()
        {
            var myProfile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            _mapper = configuration.CreateMapper();

            _sut = new CartItemsService(_repositoryMock.Object, configuration.CreateMapper());
        }

        [Fact]
        public async Task getAllCartItems_ShouldReturnCarItems_WhenCarItemsExist()
        {
            // Arrange
            var cartItemId = 1;
            var quantity = 3;
            var productId = 1;
            var cartId = 1;
            var cartItem = new CartItems(cartItemId, quantity, productId, cartId);

            var cartItemId2 = 2;
            var quantity2 = 3;
            var productId2 = 1;
            var cartId2 = 1;
            var cartItem2 = new CartItems(cartItemId2, quantity2, productId2, cartId2);

            var cartItemId3 = 3;
            var quantity3 = 5;
            var productId3 = 1;
            var cartId3 = 1;
            var cartItem3 = new CartItems(cartItemId3, quantity3, productId3, cartId3);

            var cartItemId4 = 4;
            var quantity4 = 2;
            var productId4 = 2;
            var cartId4 = 1;
            var cartItem4 = new CartItems(cartItemId4, quantity4, productId4, cartId4);

            CartItems[] cartItems = new CartItems[4] { cartItem, cartItem2, cartItem3, cartItem4 };
            _repositoryMock.Setup(x => x.GetAllCartItemsAsync())
                .ReturnsAsync(cartItems);


            // Act
            var cartItems2 = await _sut.getAllCartItems();

            // Assert
            Assert.Equal(cartItems, cartItems2);
        }

        [Fact]
        public async Task getAllCartItems_ShouldReturnNothing_WhenCartItemsDoesntExist()
        {
            // Arrange
            _repositoryMock.Setup(x => x.GetAllCartItemsAsync())
                .ReturnsAsync(() => null);


            // Act
            var cartItems = await _sut.getAllCartItems();

            // Assert
            Assert.Null(cartItems);
        }

        [Fact]
        public async Task getCartItemById_ShouldReturnCarItem_WhenCartItemExist()
        {
            // Arrange
            var cartItemId = 1;
            var quantity = 3;
            var productId = 1;
            var cartId = 1;
            var cartItem = new CartItems(cartItemId, quantity, productId, cartId);

            _repositoryMock.Setup(x => x.GetCartItemsAsyncById(cartItemId))
                .ReturnsAsync(cartItem);

            // Act
            var cartItem2 = await _sut.getCartItemById(cartItemId);

            // Assert
            Assert.Equal(cartItemId, cartItem2.id);
            Assert.Equal(quantity, cartItem2.quantity);
            Assert.Equal(productId, cartItem2.productId);
            Assert.Equal(cartId, cartItem2.cartId);
        }

        [Fact]
        public async Task getCartItemById_ShouldReturnNothing_WhenCartItemDoesntExist()
        {
            // Arrange
            _repositoryMock.Setup(x => x.GetProductAsyncById(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            // Act
            var cartItem = await _sut.getCartItemById(2);

            // Assert
            Assert.Null(cartItem);
        }

        [Fact]
        public async Task getCartItemsByCartId_ShouldReturnCartItems_WhenCartItemsExist()
        {
            // Arrange
            var cartItemId = 1;
            var quantity = 3;
            var productId = 1;
            var cartId = 1;
            var cartItem = new CartItems(cartItemId, quantity, productId, cartId);

            var cartItemId2 = 2;
            var quantity2 = 3;
            var productId2 = 1;
            var cartId2 = 1;
            var cartItem2 = new CartItems(cartItemId2, quantity2, productId2, cartId2);

            var cartItemId3 = 3;
            var quantity3 = 5;
            var productId3 = 1;
            var cartId3 = 1;
            var cartItem3 = new CartItems(cartItemId3, quantity3, productId3, cartId3);

            var cartItemId4 = 4;
            var quantity4 = 2;
            var productId4 = 2;
            var cartId4 = 1;
            var cartItem4 = new CartItems(cartItemId4, quantity4, productId4, cartId4);

            CartItems[] cartItems = new CartItems[4] { cartItem, cartItem2, cartItem3, cartItem4 };

            _repositoryMock.Setup(x => x.GetAllCartItemsAsyncByCartId(cartId))
                .ReturnsAsync(cartItems);

            // Act
            var cartItems2 = await _sut.getAllCartItemsByCartId(cartId);

            // Assert
            Assert.Equal(cartItems[0].cartId, cartItems2[0].cartId);
            Assert.Equal(cartItems[0].productId, cartItems2[0].productId);
            Assert.Equal(cartItems[0].quantity, cartItems2[0].quantity);
            Assert.Equal(cartItems[0].id, cartItems2[0].id);
        }
    }
}
