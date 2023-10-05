// Interface
namespace dotnetp2.Service
{
    using dotnetp2.DTO;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IReportDeliveryConfigurationRepository
    {
        Task<ReportDeliveryConfigurationModel> GetReportDeliveryConfiguration(int id);
        Task<IEnumerable<ReportDeliveryConfigurationModel>> GetAllReportDeliveryConfigurations();
        Task<int> CreateReportDeliveryConfiguration(ReportDeliveryConfigurationModel reportDeliveryConfiguration);
        Task<bool> UpdateReportDeliveryConfiguration(ReportDeliveryConfigurationModel reportDeliveryConfiguration);
        Task<bool> DeleteReportDeliveryConfiguration(int id);
    }
}