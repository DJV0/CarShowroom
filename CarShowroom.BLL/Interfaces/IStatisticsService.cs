using System.Threading.Tasks;
using CarShowroom.Models.Statistics;


namespace CarShowroom.BLL.Interfaces
{
    public interface IStatisticsService
    {
        Task<MenAndWomenPercengate> GetPercentageOfMenAndWomenInService();
        Task<int> GetAverageMileageForPartReplacement(string partName);
    }
}
