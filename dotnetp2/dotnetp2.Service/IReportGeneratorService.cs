
using System.Threading.Tasks;
using dotnetp2.DTO;

namespace dotnetp2.Service
{
    public interface IReportGeneratorService
    {
        Task GenerateReport(ReportDeliveryConfiguration deliveryConfiguration, FileType fileType);
    }
}
