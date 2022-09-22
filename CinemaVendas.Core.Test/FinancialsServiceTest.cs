using CinemaVendas.Core.Models;
using CinemaVendas.Core.Repositories.Interfaces;
using CinemaVendas.Core.Services;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CinemaVendas.Core.Test
{
    public class FinancialsServiceTest
    {
        //exercício, cirar esse setup com a controler
        private Mock<ITicketRepository> _ticketRepo;
        private Mock<IFoodRepository> _foodRepo;
        private FinancialsService _financialsService;

        public FinancialsServiceTest()
        {
            _ticketRepo = new Mock<ITicketRepository>();
            _foodRepo = new Mock<IFoodRepository>();
            _financialsService = new FinancialsService(_ticketRepo.Object, _foodRepo.Object);
        }

        [Fact]
        public void GetTotalSold_SumFoodsAndTickets_ReturnRightAmount()
        {
            //Arrange
            _foodRepo.Setup(repo => repo.GetAllSold())
                .Returns(new List<FoodItem>()
                {
                    new FoodItem()
                    {
                        ID = 14,
                        Name = "Milk Duds",
                        SalePrice = 11.0M,
                        UnitPrice = 1.0M,
                        Quantity = 10
                    },
                    new FoodItem()
                    {
                        ID = 3,
                        Name = "Sour Gummy Worms",
                        SalePrice = 11.0M,
                        UnitPrice = 1.0M,
                        Quantity = 10
                    }
                });

            _ticketRepo.Setup(repo => repo.GetAllSold())
                .Returns(new List<Ticket>()
                {
                    new Ticket()
                    {
                        ID = 1953772,
                        MovieName = "Joker",
                        SalePrice = 10.0M,
                        StudioCutPercentage = 0.5M,
                        Quantity = 10
                    },
                    new Ticket()
                    {
                        ID = 2817721,
                        MovieName = "Toy Story 4",
                        SalePrice = 10.0M,
                        StudioCutPercentage = 0.5M,
                        Quantity = 10
                    }
                });

            //Act
            var result = _financialsService.GetTotalSold();

            //Assert
            Assert.Equal(300, result);
        }
    }
}
