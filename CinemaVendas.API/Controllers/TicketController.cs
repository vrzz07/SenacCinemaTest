using CinemaVendas.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CinemaVendas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public IActionResult GetTickets()
        {
            var result = _ticketService.GetAllSold();

            if (result.Count < 1)
                return NotFound(result);

            return Ok(result);
        }
        [HttpGet]
        public string Ola()
        {
            return "Olá Mundo " + DateTime.Now.Day;
        }
    }
}
