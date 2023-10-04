
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dotnetp2
{
    public class PreferencesModel
    {
        public int Id { get; set; }

        [Required]
        public DeliveryMethod DeliveryMethod { get; set; }

        [Required]
        public FileType FileType { get; set; }

        [Required]
        public string Destination { get; set; }

        [Required]
        public DeliveryFrequency DeliveryFrequency { get; set; }

        public EmailPreferences EmailPreferences { get; set; }

        public FtpPreferences FtpPreferences { get; set; }

        public SharepointPreferences SharepointPreferences { get; set; }

        public SchedulePreferences SchedulePreferences { get; set; }

        public SuccessNotificationPreferences SuccessNotificationPreferences { get; set; }
    }

    public enum DeliveryMethod
    {
        Email,
        FTP,
        Sharepoint
    }

    public enum FileType
    {
        // TODO: Add published file types here
    }

    public class EmailPreferences
    {
        public List<string> EmailAddresses { get; set; }

        public string Subject { get; set; }

        public string BodyText { get; set; }
    }

    public class FtpPreferences
    {
        public string Url { get; set; }

        public string Password { get; set; }

        public string FilePath { get; set; }
    }

    public class SharepointPreferences
    {
        public string Url { get; set; }

        public string DocumentLibrary { get; set; }
    }

    public class SchedulePreferences
    {
        public string DeliveryDay { get; set; }

        public string DeliveryTime { get; set; }
    }

    public class SuccessNotificationPreferences
    {
        public List<string> EmailAddresses { get; set; }

        public string Subject { get; set; }

        public string BodyText { get; set; }

        public string Formatting { get; set; }
    }
}
