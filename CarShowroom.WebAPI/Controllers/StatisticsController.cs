using AutoMapper;
using CarShowroom.BLL.Interfaces;
using CarShowroom.Models.Statistics;
using CarShowroom.WebAPI.DTOs;
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
        private readonly IMapper _mapper;
        private readonly ILogger<StatisticsController> _logger;
        public StatisticsController(IStatisticsService statisticsService, IMapper mapper, ILogger<StatisticsController> logger)
        {
            _statisticsService = statisticsService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("GetMenAndWomenPercengateInOrders")]
        public async Task<MenAndWomenPercengate> GetMenAndWomenPercengateInOrders()
        {
            _logger.LogInformation("Getting statistics of men and women percentage in orders");

            return await _statisticsService.GetPercentageOfMenAndWomenInService();
        }

        [HttpGet("GetAverageMileageForPartReplacement")]
        public async Task<int> GetAverageMileageForPartReplacement(string partName, string Make, string Model)
        {
            _logger.LogInformation("Getting statistics of average mileage for part replacement");

            return await _statisticsService.GetAverageMileageForPartReplacement(partName, Make, Model);
        }

        [HttpGet("GetEmployeeOrdersInProgress")]
        public async Task<IEnumerable<OrderDTO>> GetEmployeeOrdersInProgress(string name, string lastName)
        {
            _logger.LogInformation("Getting statistics of employee orders in progress");

            var result = await _statisticsService.GetEmployeeOrdersInProgress(name, lastName);
            return _mapper.Map<IEnumerable<OrderDTO>>(result);
        }

        [HttpGet("GetOrdersAmountInCurrentMonth")]
        public async Task<IEnumerable<OrderDTO>> GetOrdersAmountInCurrentMonth()
        {
            _logger.LogInformation("Getting statistics of orders amount in current month");

            var result = await _statisticsService.GetOrdersAmountInCurrentMonth();
            return _mapper.Map<IEnumerable<OrderDTO>>(result);
        }

        [HttpGet("GetTheMostPopularCarInService")]
        public async Task<string> GetTheMostPopularCarInService()
        {
            _logger.LogInformation("Getting statistics of the most popular car in service");

            return await _statisticsService.GetTheMostPopularCarInService();
        }

        [HttpGet("GetCarInShowroomByMake")]
        public async Task<IEnumerable<CarDTO>> GetCarInShowroomByMake(string make)
        {
            _logger.LogInformation("Getting statistics of car in showroom by make");

            var result = await _statisticsService.GetCarInShowroomByMake(make);
            return _mapper.Map<IEnumerable<CarDTO>>(result);
        }

        [HttpGet("GetCarPartThatBreakDownMostOften")]
        public async Task<string> GetCarPartThatBreakDownMostOften(string make, string model)
        {
            return await _statisticsService.GetCarPartThatBreakDownMostOften(make, model);
        }
    }
}
