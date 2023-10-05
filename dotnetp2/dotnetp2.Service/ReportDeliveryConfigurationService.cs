SharePoint,
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

//Class
namespace dotnetp2.Service
{
    using dotnetp2.DataAccess;
    using dotnetp2.DTO;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ReportDeliveryConfigurationService : IReportDeliveryConfigurationService
    {
        private readonly IReportDeliveryConfigurationRepository _reportDeliveryConfigurationRepository;
        public ReportDeliveryConfigurationService(IReportDeliveryConfigurationRepository reportDeliveryConfigurationRepository)
        {
            _reportDeliveryConfigurationRepository = reportDeliveryConfigurationRepository;
        }

        public async Task<ReportDeliveryConfigurationModel> GetReportDeliveryConfiguration(int id)
        {
            return await _reportDeliveryConfigurationRepository.GetReportDeliveryConfiguration(id);
        }

        public async Task<IEnumerable<ReportDeliveryConfigurationModel>> GetAllReportDeliveryConfigurations()
        {
            return await _reportDeliveryConfigurationRepository.GetAllReportDeliveryConfigurations();
        }

        public async Task<int> CreateReportDeliveryConfiguration(ReportDeliveryConfigurationModel reportDeliveryConfiguration)
        {
            // Validate user-provided values for DayOfWeek or DayOfMonth based on the Custom frequency selection.
            ValidateDestination(reportDeliveryConfiguration);

            // Validate and store the user-provided values for DayOfWeek or DayOfMonth based on the Custom frequency selection.
            ValidateDeliveryConfiguration(reportDeliveryConfiguration);

            // Create a ReportDeliveryConfigurationModel in the Database
            return await _reportDeliveryConfigurationRepository.CreateReportDeliveryConfiguration(reportDeliveryConfiguration);
        }

        public async Task<bool> UpdateReportDeliveryConfiguration(ReportDeliveryConfigurationModel reportDeliveryConfiguration)
        {
            // Validate user-provided values for DayOfWeek or DayOfMonth based on the Custom frequency selection.
            ValidateDestination(reportDeliveryConfiguration);

            // Validate and store the user-provided values for DayOfWeek or DayOfMonth based on the Custom frequency selection.
            ValidateDeliveryConfiguration(reportDeliveryConfiguration);

            // Update the ReportDeliveryConfigurationModel in the Database
            return await _reportDeliveryConfigurationRepository.UpdateReportDeliveryConfiguration(reportDeliveryConfiguration);
        }

        public async Task<bool> DeleteReportDeliveryConfiguration(int id)
        {
            return await _reportDeliveryConfigurationRepository.DeleteReportDeliveryConfiguration(id);
        }

        private void ValidateDestination(ReportDeliveryConfigurationModel reportDeliveryConfiguration)
        {
            // Validate the DestinationAddress based on the selected DestinationType
            switch (reportDeliveryConfiguration.DestinationType)
            {
                case DestinationType.Email:
                    // Validate Email
                    if (string.IsNullOrWhiteSpace(reportDeliveryConfiguration.DestinationAddress))
                    {
                        throw new ArgumentException("Email must be provided!");
                    }
                    break;

                case DestinationType.FTP:
                    // Validate FTP
                    if (string.IsNullOrWhiteSpace(reportDeliveryConfiguration.DestinationAddress))
                    {
                        throw new ArgumentException("FTP URL must be provided!");
                    }
                    break;

                case DestinationType.SharePoint:
                    // Validate SharePoint
                    if (string.IsNullOrWhiteSpace(reportDeliveryConfiguration.DestinationAddress))
                    {
                        throw new ArgumentException("SharePoint URL must be provided!");
                    }
                    break;

                case DestinationType.Custom:
                    // Validate Custom
                    if (string.IsNullOrWhiteSpace(reportDeliveryConfiguration.DestinationAddress))
                    {
                        throw new ArgumentException("Custom URL must be provided!");
                    }
                    break;
            }
        }

        private void ValidateDeliveryConfiguration(ReportDeliveryConfigurationModel reportDeliveryConfiguration)
        {
            // Validate the FrequencyType, DayOfWeek, DayOfMonth, and DeliveryTime
            if (reportDeliveryConfiguration.FrequencyType == FrequencyType.Custom)
            {
                if (string.IsNullOrWhiteSpace(reportDeliveryConfiguration.DayOfWeek) && string.IsNullOrWhiteSpace(reportDeliveryConfiguration.DayOfMonth))
                {
                    throw new ArgumentException("DayOfWeek or DayOfMonth must be provided for Custom Frequency");
                }
            }

            if (reportDeliveryConfiguration.DeliveryTime == TimeSpan.Zero)
            {
                throw new ArgumentException("DeliveryTime must be provided!");