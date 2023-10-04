namespace dotnetp2
{
    public enum DestinationType
    {
        Email,
        CloudStorage,
        InternalServer
    }

    public class ReportDeliveryConfigurationModel
    {
        public DestinationType DestinationType { get; set; }
        public string DestinationAddress { get; set; }

        public void ValidateDestination()
        {
            // TODO: Implement validation logic for DestinationAddress based on DestinationType
        }
    }

    public class ReportGenerator
    {
        public FileType GenerateReport(DestinationType fileType)
        {
            // TODO: Implement logic for generating reports based on the selected file type
            return FileType.PDF;
        }
    }

    public enum FileType
    {
        PDF,
        CSV,
        Excel,
        Custom
    }

    public class SharePointIntegrationModel
    {
        public string SharePointUrl { get; set; }
        public string DocumentLibraryName { get; set; }
    }

    public class ScheduleConfigurationModel
    {
        public FileType ReportFileType { get; set; }
        public ReportDeliveryConfigurationModel DeliveryConfiguration { get; set; }
        public string CustomFormat { get; set; }
        public FrequencyType FrequencyType { get; set; }
        public int DayOfWeek { get; set; }
        public int DayOfMonth { get; set; }
        public TimeSpan DeliveryTime { get; set; }

        public void ValidateDeliveryConfiguration()
        {
            // TODO: Implement validation logic for FrequencyType, DayOfWeek, DayOfMonth, and DeliveryTime
        }
    }

    public enum FrequencyType
    {
        DaysOfWeek,
        DaysOfMonth
    }
}