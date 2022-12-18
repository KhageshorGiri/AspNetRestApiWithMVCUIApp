using Catelog.API.Controllers;
using Catelog.API.Dtos.ProductDtos;
using Catelog.API.Interfaces;
using Catelog.API.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Serialization;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApi.Test.Controllers
{
    public class ProductControllerTest
    {
        private readonly Mock<IProduct> repositoryStub = new();
        private readonly Random random = new Random();


        // signature for writing a wint test function
        //[Fact]
        //// naming convention
        //// UnityOfWork_StateUnderTest_ExpectedBehavior()
        //public void TestPlatformContractResolver1()
        //{
        //    // Arrange

        //    // Act

        //    // Assert
        //}


        [Fact]
        public async Task GetProductAsync_WithNonExistingItem_ReturnNotFound()
        {
            // Arrange
            repositoryStub.Setup(x => x.GetProductAsync(It.IsAny<Guid>())).
                ReturnsAsync((Product?)null);

            var controller = new ProductsController(repositoryStub.Object);

            // Act
            var result = await controller.GetProductAsync(new Guid());

            // Assert
            Assert.IsType<NotFoundResult>(result.Result); // normal manual way to do assertion
        }


        [Fact]
        public async Task GetProductAsync_WithExistingItem_ReturnExperctedItem()
        {
            // Arrange
            var expectedItem = CreateRandomItem();

            repositoryStub.Setup(x => x.GetProductAsync(It.IsAny<Guid>())).
                ReturnsAsync(expectedItem);

            var controller = new ProductsController(repositoryStub.Object);

            //Act
            var result = await controller.GetProductAsync(Guid.NewGuid());

            //Assert
            result.Value.Should().BeEquivalentTo(expectedItem, 
                options => options.ComparingByMembers<Product>().ExcludingMissingMembers());
        }


        [Fact]
        public async Task GetProductsAsync_WithAllExistingItem_ReturnAllExperctedItem()
        {
            // Arrange
            var expectedItem = new[] { CreateRandomItem(), CreateRandomItem(), CreateRandomItem()};

            repositoryStub.Setup(x => x.GetProductsAsync()).
                ReturnsAsync(expectedItem);

            var controller = new ProductsController(repositoryStub.Object);

            //Act
            var result = await controller.GetProductsAsync();

            //Assert
            result.Should().BeEquivalentTo(expectedItem,
                options => options.ComparingByMembers<Product>().ExcludingMissingMembers());
        }

        [Fact]
        public async Task CreateProductAsync_CreateNewProduct_ReturnNoContent()
        {
            // Arange 
            var itemToCreate = new CreateProductDto()
            {
                ProductName = Guid.NewGuid().ToString(),
                ProductDescription = Guid.NewGuid().ToString(),
                ProductPrice = random.Next(60000)
            };

            var controller = new ProductsController(repositoryStub.Object);

            // Act
            var result = await controller.CreateProductAsync(itemToCreate);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task UpdateProductAsync_WithExistingItem_ReturnNoContent()
        {
            // Arange
            var expectedItem = CreateRandomItem();
            var itemId = expectedItem.ProductID;
            repositoryStub.Setup(x => x.GetProductAsync(It.IsAny<Guid>())).
                ReturnsAsync(expectedItem);

            var itemTobeUpdate = new UpdateProductDto()
            {
                ProductName = Guid.NewGuid().ToString(),
                ProductDescription = Guid.NewGuid().ToString(),
                ProductPrice = random.Next(60000)
            };

            var controller = new ProductsController(repositoryStub.Object);

            // Act
            var result = await controller.UpdateProductAsync(itemId, itemTobeUpdate);

            // Assert
            result.Should().BeOfType<NoContentResult>();
        }

        [Fact]
        public async Task DeleteProductAsync_WithExistingItem_ReturnNoContent()
        {
            // Arange
            var expectedItem = CreateRandomItem(); 
            var itemId = expectedItem.ProductID;
            repositoryStub.Setup(x => x.GetProductAsync(It.IsAny<Guid>())).
                ReturnsAsync(expectedItem);

            var controller = new ProductsController(repositoryStub.Object);

            // Act
            var result = await controller.DeleteProductAsync(itemId);

            // Assert
            result.Should().BeOfType<NoContentResult>();
        }

        private Product CreateRandomItem()
        {
            return new()
            {
                ProductID = new Guid(),
                ProductName = new Guid().ToString(),
                ProductDescription = new Guid().ToString(),
                ProductPrice = random.Next(1000),
                CreatedDate = DateTime.UtcNow,
                UpdatedDate  = DateTime.UtcNow
            };
        }
    }
}
