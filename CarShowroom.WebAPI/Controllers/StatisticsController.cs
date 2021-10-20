using CarShowroom.BLL.Interfaces;
using CarShowroom.Models.Statistics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowroom.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;
        private readonly ILogger<StatisticsController> _logger;
        public StatisticsController(IStatisticsService statisticsService, ILogger<StatisticsController> logger)
        {
            _statisticsService = statisticsService;
            _logger = logger;
        }

        [HttpGet("GetMenAndWomenPercengateInOrders")]
        public async Task<ActionResult<MenAndWomenPercengate>> GetMenAndWomenPercengateInOrders()
        {
            _logger.LogInformation("Getting statistics of men and women percentage in orders");

            return await _statisticsService.GetPercentageOfMenAndWomenInService();
        }
    }
}
