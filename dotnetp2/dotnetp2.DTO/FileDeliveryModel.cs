
namespace dotnetp2
{
    public class FileDeliveryModel
    {
        public int Id { get; set; }

        public string DeliveryMethod { get; set; }

        public string AttachmentFormat { get; set; }

        public string FTPUrl { get; set; }

        public string FTPPassword { get; set; }

        public string FTPFilePath { get; set; }

        public string SharepointUrl { get; set; }

        public string SharepointDocumentLibrary { get; set; }

        public string DeliverySchedule { get; set; }

        public string SpecificDay { get; set; }

        public string TimeOfDay { get; set; }

        public string SuccessNotificationEmails { get; set; }

        public string SuccessNotificationSubject { get; set; }

        public string SuccessNotificationBody { get; set; }
    }
}
