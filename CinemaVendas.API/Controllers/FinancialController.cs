using CinemaVendas.Core.Services;
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
    public class FinancialController : ControllerBase
    {
        private readonly IFinancialsService _financialService;

        public FinancialController(FinancialsService financialsService)
        {
            _financialService = financialsService;
        }

        public IActionResult GetTotalSold()
        {
            return Ok(_financialService.GetTotalSold());
        }
    }
}
