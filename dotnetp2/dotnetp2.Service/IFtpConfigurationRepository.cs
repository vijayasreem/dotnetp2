﻿public interface IFtpConfigurationRepository
{
    Task<int> CreateFtpConfigurationAsync(FtpConfigurationModel model);
    Task<FtpConfigurationModel> GetFtpConfigurationAsync(int id);
    Task<int> UpdateFtpConfigurationAsync(FtpConfigurationModel model);
    Task<int> DeleteFtpConfigurationAsync(int id);
}