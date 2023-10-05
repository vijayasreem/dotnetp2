namespace dotnetp2
{
    public class ReportConfigurationModel
    {
        public int Id { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public string EmailAddress { get; set; }
        public string Subject { get; set; }
        public string BodyText { get; set; }
        public string FTPURL { get; set; }
        public string FTPCredential { get; set; }
        public string FilePath { get; set; }
        public string SharePointURL { get; set; }
        public string DocumentLibrary { get; set; }
        public string Schedule { get; set; }
        public string FileType { get; set; }
        public string SuccessNotificationEmailAddress { get; set; }
        public string SuccessNotificationSubject { get; set; }
        public string SuccessNotificationBodyText { get; set; }
        public string SuccessNotificationFormatting { get; set; }
    }

    public enum DeliveryMethod
    {
        Email, 
        FTP, 
        SharePoint
    }
}