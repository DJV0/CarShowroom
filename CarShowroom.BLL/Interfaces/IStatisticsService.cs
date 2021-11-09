using System.Collections.Generic;
using System.Threading.Tasks;
using CarShowroom.Models.Entities;
using CarShowroom.Models.Statistics;


namespace CarShowroom.BLL.Interfaces
{
    public interface IStatisticsService
    {
        Task<MenAndWomenPercengate> GetPercentageOfMenAndWomenInService();
        Task<int> GetAverageMileageForPartReplacement(string partName, string Make, string Model);
        Task<IEnumerable<Order>> GetEmployeeOrdersInProgress(string name, string lastName);
        Task<int> GetOrdersAmountInCurrentMonth();
        Task<string> GetTheMostPopularCarInService();
        Task<IEnumerable<Car>> GetCarInShowroomByMake(string make);
        Task<string> GetCarPartThatBreakDownMostOften(string make, string model);
    }
}
