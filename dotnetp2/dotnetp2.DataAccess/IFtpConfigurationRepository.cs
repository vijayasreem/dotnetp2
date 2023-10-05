();
            }
        }
    }
}

namespace dotnetp2.Service
{
    public interface IFtpConfigurationRepository
    {
        Task<int> CreateAsync(FtpConfigurationModel model);
        Task<FtpConfigurationModel> ReadAsync(int id);
        Task<bool> UpdateAsync(FtpConfigurationModel model);
        Task<bool> DeleteAsync(int id);
    }
}