namespace dotnetp2.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        // POST api/email
        [HttpPost]
        public async Task<IActionResult> SendEmailAsync([FromBody] EmailDTO emailDTO)
        {
            try
            {
                var result = await _emailService.SendSmtpEmailAsync(
                    emailDTO.From, 
                    emailDTO.To, 
                    emailDTO.Subject, 
                    emailDTO.Body, 
                    emailDTO.AttachmentPath);
                if (result)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/upload
        [HttpPost]
        public async Task<IActionResult> UploadFileAsync([FromForm] UploadFileDTO uploadFileDTO)
        {
            try
            {
                if (uploadFileDTO.DestinationType == FileDestinationType.FTP)
                {
                    var result = await _emailService.SendFileToFTPAsync(uploadFileDTO.SourceFilePath, uploadFileDTO.DestinationFilePath);
                    if (result)
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else if (uploadFileDTO.DestinationType == FileDestinationType.SharePoint)
                {
                    var result = await _emailService.SendFileToSharepointAsync(uploadFileDTO.SourceFilePath, uploadFileDTO.DestinationFilePath);
                    if (result)
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/process
        [HttpPost]
        public async Task<IActionResult> ProcessRequestsAsync()
        {
            try
            {
                var result = await _emailService.ProcessRequestsAsync();
                if (result)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}