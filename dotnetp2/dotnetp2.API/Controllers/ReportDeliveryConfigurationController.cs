
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetp2.DTO;
using dotnetp2.Service;
using Microsoft.AspNetCore.Mvc;

namespace dotnetp2.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportDeliveryConfigurationController : ControllerBase
    {
        private readonly IReportDeliveryConfigurationService _reportDeliveryConfigurationService;

        public ReportDeliveryConfigurationController(IReportDeliveryConfigurationService reportDeliveryConfigurationService)
        {
            _reportDeliveryConfigurationService = reportDeliveryConfigurationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReportDeliveryConfigurationModel>>> GetAllAsync()
        {
            var configurations = await _reportDeliveryConfigurationService.GetAllAsync();
            return Ok(configurations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReportDeliveryConfigurationModel>> GetByIdAsync(int id)
        {
            var configuration = await _reportDeliveryConfigurationService.GetByIdAsync(id);
            if (configuration == null)
            {
                return NotFound();
            }
            return Ok(configuration);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddAsync(ReportDeliveryConfigurationModel configuration)
        {
            var id = await _reportDeliveryConfigurationService.AddAsync(configuration);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, ReportDeliveryConfigurationModel configuration)
        {
            if (id != configuration.Id)
            {
                return BadRequest();
            }

            await _reportDeliveryConfigurationService.UpdateAsync(configuration);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _reportDeliveryConfigurationService.DeleteAsync(id);
            return NoContent();
        }
    }
}
