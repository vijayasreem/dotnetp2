﻿SharePoint,
        Custom
    }

    public enum FrequencyType
    {
        Daily,
        Weekly,
        Monthly,
        Custom
    }
}

//Interface
namespace dotnetp2.Service
{
    using dotnetp2.DataAccess;
    using dotnetp2.DTO;
    using System.Threading.Tasks;

    public interface IReportDeliveryConfigurationService
    {
        Task<ReportDeliveryConfigurationModel> GetReportDeliveryConfiguration(int id);

        Task<IEnumerable<ReportDeliveryConfigurationModel>> GetAllReportDeliveryConfigurations();

        Task<int> CreateReportDeliveryConfiguration(ReportDeliveryConfigurationModel reportDeliveryConfiguration);

        Task<bool> UpdateReportDeliveryConfiguration(ReportDeliveryConfigurationModel reportDeliveryConfiguration);

        Task<bool> DeleteReportDeliveryConfiguration(int id);
    }
}