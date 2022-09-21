using CinemaVendas.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public IActionResult GetTickets()
        {
            return Ok(_ticketService.GetAllSold());
        }
    }
}
