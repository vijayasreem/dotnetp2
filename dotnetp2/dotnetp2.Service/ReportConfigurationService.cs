public class ReportConfigurationService : IReportConfigurationRepository
{
    public async Task<int> CreateReportConfigurationAsync(ReportConfigurationModel configuration)
    {
        return await _reportConfigurationRepository.CreateReportConfigurationAsync(configuration);
    }

    public async Task<bool> UpdateReportConfigurationAsync(ReportConfigurationModel configuration)
    {
        return await _reportConfigurationRepository.UpdateReportConfigurationAsync(configuration);
    }

    public async Task<ReportConfigurationModel> GetReportConfigurationAsync(int id)
    {
        return await _reportConfigurationRepository.GetReportConfigurationAsync(id);
    }

    public async Task<bool> DeleteReportConfigurationAsync(int id)
    {
        return await _reportConfigurationRepository.DeleteReportConfigurationAsync(id);
    }
}