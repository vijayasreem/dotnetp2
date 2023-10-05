//Data Access
namespace dotnetp2.DataAccess
{
    using dotnetp2.DTO;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IReportDeliveryConfigurationDataAccess
    {
        Task<ReportDeliveryConfigurationModel> GetReportDeliveryConfiguration(int id);

        Task<IEnumerable<ReportDeliveryConfigurationModel>> GetAllReportDeliveryConfigurations();

        Task<int> CreateReportDeliveryConfiguration(ReportDeliveryConfigurationModel reportDeliveryConfiguration);

        Task<bool> UpdateReportDeliveryConfiguration(ReportDeliveryConfigurationModel reportDeliveryConfiguration);

        Task<bool> DeleteReportDeliveryConfiguration(int id);
    }
}

//DTO
namespace dotnetp2.DTO
{
    public class ReportDeliveryConfigurationModel
    {
        public int Id { get; set; }
        public FileType FileType { get; set; }
        public string CustomFormat { get; set; }
        public DestinationType DestinationType { get; set; }
        public string DestinationAddress { get; set; }
        public FrequencyType FrequencyType { get; set; }
        public int DayOfWeek { get; set; }
        public int DayOfMonth { get; set; }
        public TimeSpan DeliveryTime { get; set; }
        public string EmailAddress { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
        public string FTPURL { get; set; }
        public string FTPCredential { get; set; }
        public string FilePath { get; set; }
        public string SharePointURL { get; set; }
        public string DocumentLibraryName { get; set; }
    }
}

//API Controller
namespace dotnetp2.API
{
    using dotnetp2.DTO;
    using dotnetp2.Service;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class ReportDeliveryConfigurationController : ControllerBase
    {
        private readonly IReportDeliveryConfigurationService _reportDeliveryConfigurationService;

        public ReportDeliveryConfigurationController(IReportDeliveryConfigurationService reportDeliveryConfigurationService)
        {
            _reportDeliveryConfigurationService = reportDeliveryConfigurationService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReportDeliveryConfigurationModel>> Get(int id)
        {
            var reportDeliveryConfiguration = await _reportDeliveryConfigurationService.GetReportDeliveryConfiguration(id);
            return Ok(reportDeliveryConfiguration);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReportDeliveryConfigurationModel>>> GetAll()
        {
            var reportDeliveryConfigurations = await _reportDeliveryConfigurationService.GetAllReportDeliveryConfigurations();
            return Ok(reportDeliveryConfigurations);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ReportDeliveryConfigurationModel reportDeliveryConfiguration)
        {
            var result = await _reportDeliveryConfigurationService.CreateReportDeliveryConfiguration(reportDeliveryConfiguration);
            return CreatedAtAction(nameof(Get), new { id = result }, reportDeliveryConfiguration);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ReportDeliveryConfigurationModel reportDeliveryConfiguration)
        {
            if (id != reportDeliveryConfiguration.Id)
            {
                return BadRequest();
            }

            var result = await _reportDeliveryConfigurationService.UpdateReportDeliveryConfiguration(reportDeliveryConfiguration);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _reportDeliveryConfigurationService.DeleteReportDeliveryConfiguration(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}