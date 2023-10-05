public class ReportConfigurationRepository : IReportConfigurationRepository
{
    public async Task<int> CreateReportConfigurationAsync(ReportConfigurationModel configuration)
    {
        // Insert into Database
        // Return the newly created ID
        return await Task.FromResult(1);
    }

    public async Task<bool> UpdateReportConfigurationAsync(ReportConfigurationModel configuration)
    {
        // Update record in Database
        return await Task.FromResult(true);
    }

    public async Task<ReportConfigurationModel> GetReportConfigurationAsync(int id)
    {
        // Retrieve record from Database
        // Return the record
        return await Task.FromResult(new ReportConfigurationModel());
    }

    public async Task<bool> DeleteReportConfigurationAsync(int id)
    {
        // Delete record from Database
        return await Task.FromResult(true);
    }
}