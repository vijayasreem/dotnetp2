// Generated Interface

namespace dotnetp2.Service
{
    public interface IReportConfigurationRepository
    {
         Task<int> CreateReportConfigurationAsync(ReportConfigurationModel configuration);
         Task<bool> UpdateReportConfigurationAsync(ReportConfigurationModel configuration);
         Task<ReportConfigurationModel> GetReportConfigurationAsync(int id);
         Task<bool> DeleteReportConfigurationAsync(int id);
    }
}