using CinemaVendas.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CinemaVendas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _ticketService;

        public FoodController(IFoodService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public IActionResult GetTickets()
        {
            return Ok(_ticketService.GetAllSold());
        }
    }
}
