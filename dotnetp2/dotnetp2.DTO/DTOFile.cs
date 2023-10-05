using System.Data;
using System.IO;

namespace Dotnetp2
{
    public class SendEmailModel 
    {
        public int Id { get; set; }
        public File AttachedFile { get; set; }
        public string FileType { get; set; }
        public string DestinationType { get; set; }
        public int ScheduleTime { get; set; }
        public DataTable RequestsInformation { get; set; }
    }
}