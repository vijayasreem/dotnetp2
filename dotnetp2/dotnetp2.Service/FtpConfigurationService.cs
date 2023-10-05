using dotnetp2.DataAccess;
using dotnetp2.DTO;

namespace dotnetp2.Service
{
    public class FtpConfigurationService : IFtpConfigurationRepository
    {
        private readonly IFtpConfigurationRepository _ftpConfigurationRepository;
        public FtpConfigurationService(IFtpConfigurationRepository ftpConfigurationRepository)
        {
            _ftpConfigurationRepository = ftpConfigurationRepository;
        }

        public async Task<int> CreateFtpConfigurationAsync(FtpConfigurationModel model)
        {
            return await _ftpConfigurationRepository.CreateFtpConfigurationAsync(model);
        }

        public async Task<FtpConfigurationModel> GetFtpConfigurationAsync(int id)
        {
            return await _ftpConfigurationRepository.GetFtpConfigurationAsync(id);
        }

        public async Task<int> UpdateFtpConfigurationAsync(FtpConfigurationModel model)
        {
            return await _ftpConfigurationRepository.UpdateFtpConfigurationAsync(model);
        }

        public async Task<int> DeleteFtpConfigurationAsync(int id)
        {
            return await _ftpConfigurationRepository.DeleteFtpConfigurationAsync(id);
        }
    }
}