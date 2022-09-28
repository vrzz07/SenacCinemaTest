using CinemaVendas.API.Controllers;
using CinemaVendas.Core.Models;
using CinemaVendas.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace CinemaVendas.API.Test
{
    public class FoodControllerTest
    {
        private Mock<IFoodService> _mockFoodService;
        private FoodController _controller;

        public FoodControllerTest()
        {
            _mockFoodService = new Mock<IFoodService>();
            _controller = new FoodController(_mockFoodService.Object);
        }

        [Fact]
        public void GetFoodSold_WithData_ReturnOkResult()
        {
            //Arrange            
            _mockFoodService.Setup(service => service.GetAllSold())
                .Returns(new List<FoodItem>()
                {
                    new FoodItem() { ID = 1, Name = "Food A" },
                    new FoodItem() { ID = 2, Name = "Food B" }

                });

            //Act
            var result = _controller.GetFoodSold();

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var foodItems = Assert.IsType<List<FoodItem>>(okResult.Value);
            Assert.Equal(2, foodItems.Count);
        }

        [Fact]
        public void GetFoodSold_WithoutData_ReturnNotFound()
        {
            //Arrange            
            _mockFoodService.Setup(service => service.GetAllSold())
                .Returns(new List<FoodItem>());

            //Act
            var result = _controller.GetFoodSold();

            //Assert
            var okResult = Assert.IsType<NotFoundObjectResult>(result);
            var foodItems = Assert.IsType<List<FoodItem>>(okResult.Value);
            Assert.Empty(foodItems);
        }
    }
}
