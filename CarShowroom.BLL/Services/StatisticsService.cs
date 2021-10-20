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

        public Task<int> GetAverageMileageForPartReplacement(string partName)
        {
            throw new NotImplementedException();
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
    }
}
