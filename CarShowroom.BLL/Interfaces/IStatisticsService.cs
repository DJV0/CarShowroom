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
        Task<IEnumerable<Order>> GetOrdersAmountInCurrentMonth();
        Task<string> GetTheMostPopularCarInService();
        Task<IEnumerable<Car>> GetCarInShowroomByMake(string make);

    }
}
