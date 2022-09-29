using CinemaVendas.API.Controllers;
using CinemaVendas.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace CinemaVendas.API.Test
{
    public class FinancialControllerTest
    {
        private Mock<IFinancialsService> _mockFinancialService;
        private FinancialController _controller;

        public FinancialControllerTest()
        {
            _mockFinancialService = new Mock<IFinancialsService>();
            _controller = new FinancialController(_mockFinancialService.Object);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(21.4)]
        [InlineData(-10)]
        public void GetTotalSold_HasAmount_ReturnOkResult(decimal total)
        {
            //Arrange            
            _mockFinancialService.Setup(service => service.GetTotalSold())
                .Returns(total);

            //Act
            var result = _controller.GetTotalSold();

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var amount = Assert.IsType<Decimal>(okResult.Value);
            Assert.Equal(total +1, amount);
        }
    }
}
