using System.Threading.Tasks;
using dotnetp2.DTO;
using dotnetp2.Service;
using Microsoft.AspNetCore.Mvc;

namespace dotnetp2.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class FtpConfigurationController : ControllerBase
    {
        private readonly IFtpConfigurationRepository _ftpConfigurationRepository;

        public FtpConfigurationController(IFtpConfigurationRepository ftpConfigurationRepository)
        {
            _ftpConfigurationRepository = ftpConfigurationRepository;
        }

        [HttpPost]
        [Route("CreateFtpConfiguration")]
        public async Task<IActionResult> CreateFtpConfigurationAsync([FromBody]FtpConfigurationModel model)
        {
            var result = await _ftpConfigurationRepository.CreateFtpConfigurationAsync(model);

            if (result <= 0)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("GetFtpConfiguration/{id}")]
        public async Task<IActionResult> GetFtpConfigurationAsync(int id)
        {
            var result = await _ftpConfigurationRepository.GetFtpConfigurationAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateFtpConfiguration")]
        public async Task<IActionResult> UpdateFtpConfigurationAsync([FromBody]FtpConfigurationModel model)
        {
            var result = await _ftpConfigurationRepository.UpdateFtpConfigurationAsync(model);

            if (result <= 0)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteFtpConfiguration/{id}")]
        public async Task<IActionResult> DeleteFtpConfigurationAsync(int id)
        {
            var result = await _ftpConfigurationRepository.DeleteFtpConfigurationAsync(id);

            if (result <= 0)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}