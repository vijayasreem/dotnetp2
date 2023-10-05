namespace dotnetp2.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportConfigurationRepository _reportConfigurationRepository;
        public ReportsController(IReportConfigurationRepository reportConfigurationRepository)
        {
            _reportConfigurationRepository = reportConfigurationRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReportConfigurationAsync(ReportConfigurationModel configuration)
        {
            var newId = await _reportConfigurationRepository.CreateReportConfigurationAsync(configuration);
            return Ok(newId);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReportConfigurationAsync(ReportConfigurationModel configuration)
        {
            var success = await _reportConfigurationRepository.UpdateReportConfigurationAsync(configuration);
            return Ok(success);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReportConfigurationAsync(int id)
        {
            var reportConfiguration = await _reportConfigurationRepository.GetReportConfigurationAsync(id);
            return Ok(reportConfiguration);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReportConfigurationAsync(int id)
        {
            var success = await _reportConfigurationRepository.DeleteReportConfigurationAsync(id);
            return Ok(success);
        }
    }
}