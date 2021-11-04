using Carshowroom.DAL;
using CarShowroom.BLL.Interfaces;
using CarShowroom.Models.Entities;
using CarShowroom.Models.Statistics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.BLL.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly CarShowroomDbContext _context;
        public StatisticsService(CarShowroomDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetAverageMileageForPartReplacement(string partName, string Make, string Model)
        {
            return (int)await _context.Orders
                .Include(o=>o.Car)
                .Include(o=>o.OrderParts)
                .ThenInclude(op=>op.Part)
                .Where(o=>o.OrderParts.Any(op=>op.Part.Name == partName))
                .Where(o => o.Car.Make == Make && o.Car.Model == Model)
                .AverageAsync(o => o.Car.Mileage);
        }

        public async Task<IEnumerable<Car>> GetCarInShowroomByMake(string make)
        {
           return await _context.Cars
                .Where(c => c.Make == make && c.ClientId == default)
                .ToListAsync();
        }

        public async Task<string> GetCarPartThatBreakDownMostOften(string make, string model)
        {
            var result = await _context.Orders
                .Include(o => o.Car)
                .Include(o => o.OrderParts)
                .ThenInclude(op => op.Part)
                .Where(o => o.Car.Make == make && o.Car.Model == model)
                .SelectMany(o => o.OrderParts, (o, op) => new
                {
                    Order = o,
                    Part = op.Part.Name
                })
                .GroupBy(x => x.Part)
                .Select(x => new
                {
                    Part = x.Key,
                    Amount = x.Count()
                })
                .OrderByDescending(x => x.Amount)
                .FirstOrDefaultAsync();
            return result.Part;
        }

        public async Task<IEnumerable<Order>> GetEmployeeOrdersInProgress(string name, string lastName)
        {
            return await _context.Orders
                .Include(o => o.Car)
                .Include(o => o.OrderEmployees)
                .ThenInclude(oe => oe.Employee)
                .Where(o => o.OrderEmployees.Any(oe => oe.Employee.Name == name && oe.Employee.LastName == lastName)
                    && o.EndingOfWork > DateTime.Now)
                .ToListAsync();
        }

        public async Task<int> GetOrdersAmountInCurrentMonth()
        {
            var orderList = await _context.Orders
                .Include(o => o.Car)
                .Where(o => o.BeginningOfWork.Year == DateTime.Now.Year && o.BeginningOfWork.Month == DateTime.Now.Month)
                .ToListAsync();
            var result = orderList.Count;
            await AddValueToDataBase(nameof(GetOrdersAmountInCurrentMonth), result.ToString());
            return result;

        }

        public async Task<MenAndWomenPercengate> GetPercentageOfMenAndWomenInService()
        {
            var genderList = await _context.Orders
                .Include(o => o.Car)
                .ThenInclude(c => c.Client)
                .Select(o => o.Car.Client)
                .GroupBy(c => c.Gender)
                .Select(g => new
                {
                    Gender = g.Key,
                    Amount = g.Count()
                })
                .ToListAsync();
            int peopleSum = genderList.Sum(g => g.Amount);
            return new MenAndWomenPercengate()
            {
                MenPercentage = (double)genderList
                                    .FirstOrDefault(list => list.Gender == Gender.Male).Amount / peopleSum * 100,
                WomenPercentage = (double)genderList
                                    .FirstOrDefault(list => list.Gender == Gender.Female).Amount / peopleSum * 100
            };
        }

        public async Task<string> GetTheMostPopularCarInService()
        {
            var car = await _context.Orders
                .Include(o => o.Car)
                .GroupBy(o => o.Car.Make)
                .Select(g => new
                {
                    Make = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(a => a.Count)
                .FirstOrDefaultAsync();
            await AddValueToDataBase(nameof(GetTheMostPopularCarInService), car.Make);
            return car.Make;
        }

        private async Task AddValueToDataBase(string statisticsName, string value)
        {
            var stat = new Statistics()
            {
                Name = statisticsName,
                Value = value
            };
            var statEntity = await _context.Statistics.FindAsync(stat.Name);
            if (statEntity == null) await _context.Statistics.AddAsync(stat);
            else _context.Entry(statEntity).CurrentValues.SetValues(stat);

            await _context.SaveChangesAsync();
        }
    }
}
