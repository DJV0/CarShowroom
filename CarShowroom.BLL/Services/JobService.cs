using CarShowroom.BLL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.BLL.Services
{
    public class JobService : IJobService
    {
        private readonly IStatisticsService _statisticsService;
        private readonly ILogger<JobService> _logger;
        public JobService(IStatisticsService statisticsService, ILogger<JobService> logger)
        {
            _statisticsService = statisticsService;
            _logger = logger;
        }
        public async Task UpdateStatisticsJob()
        {
            _logger.LogInformation("Updating statistics data.");
            await _statisticsService.GetOrdersAmountInCurrentMonth();
            await _statisticsService.GetTheMostPopularCarInService();
        }
    }
}
