using dotnetp2.API;
using dotnetp2.DTO;
using dotnetp2.Service;
using Microsoft.AspNetCore.Mvc;

namespace dotnetp2.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class FTPConfigController : ControllerBase
    {
        private readonly IFTPConfigService _ftpConfigService;

        public FTPConfigController(IFTPConfigService ftpConfigService)
        {
            _ftpConfigService = ftpConfigService;
        }

        [HttpPost]
        public async Task<IActionResult> ConfigureFTP(FTPConfigDTO ftpConfigDTO)
        {
            if (ModelState.IsValid)
            {
                bool result = await _ftpConfigService.ConfigureFTP(ftpConfigDTO.FtpUrl, ftpConfigDTO.Password, ftpConfigDTO.FilePath);
                if (result)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}