using CinemaVendas.API.Controllers;
using CinemaVendas.Core.Models;
using CinemaVendas.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace CinemaVendas.API.Test
{
    public class TicketControllerTest
    {
        private Mock<ITicketService> _mockTicketService;
        private TicketController _controller;

        public TicketControllerTest()
        {
            _mockTicketService = new Mock<ITicketService>();
            _controller = new TicketController(_mockTicketService.Object);
        }

        [Fact]
        public void GetTickets_WithData_ReturnOkResult()
        {
            //Arrange            
            _mockTicketService.Setup(service => service.GetAllSold())
                .Returns(new List<Ticket>()
                {
                    new Ticket() { ID = 1, MovieName = "Movie A" },
                    new Ticket() { ID = 2, MovieName = "Ticket B" }

                });

            //Act
            var result = _controller.GetTickets();

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var tickets = Assert.IsType<List<Ticket>>(okResult.Value);
            Assert.Equal(2, tickets.Count);
        }

        [Fact]
        public void GetTickets_WithoutData_ReturnNotFound()
        {
            //Arrange            
            _mockTicketService.Setup(service => service.GetAllSold())
                .Returns(new List<Ticket>());

            //Act
            var result = _controller.GetTickets();

            //Assert
            var okResult = Assert.IsType<NotFoundObjectResult>(result);
            var tickets = Assert.IsType<List<Ticket>>(okResult.Value);
            Assert.Empty(tickets);
        }
    }
}
