
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetp2.DTO;

namespace dotnetp2.Service
{
    public interface IReportDeliveryConfigurationService
    {
        Task<List<ReportDeliveryConfigurationModel>> GetAllAsync();
        Task<ReportDeliveryConfigurationModel> GetByIdAsync(int id);
        Task<int> AddAsync(ReportDeliveryConfigurationModel configuration);
        Task UpdateAsync(ReportDeliveryConfigurationModel configuration);
        Task DeleteAsync(int id);
    }
}
