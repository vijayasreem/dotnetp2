
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetp2.DTO;
using dotnetp2.Service;
using Microsoft.AspNetCore.Mvc;

namespace dotnetp2.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileDeliveryController : ControllerBase
    {
        private readonly IFileDeliveryService _fileDeliveryService;

        public FileDeliveryController(IFileDeliveryService fileDeliveryService)
        {
            _fileDeliveryService = fileDeliveryService;
        }

        [HttpGet]
        public async Task<IEnumerable<FileDeliveryModel>> GetAllFileDeliveryModelsAsync()
        {
            return await _fileDeliveryService.GetAllFileDeliveryModelsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FileDeliveryModel>> GetFileDeliveryModelByIdAsync(int id)
        {
            var fileDeliveryModel = await _fileDeliveryService.GetFileDeliveryModelByIdAsync(id);
            if (fileDeliveryModel == null)
            {
                return NotFound();
            }
            return fileDeliveryModel;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddFileDeliveryModelAsync(FileDeliveryModel fileDeliveryModel)
        {
            var id = await _fileDeliveryService.AddFileDeliveryModelAsync(fileDeliveryModel);
            return CreatedAtAction(nameof(GetFileDeliveryModelByIdAsync), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFileDeliveryModelAsync(int id, FileDeliveryModel fileDeliveryModel)
        {
            if (id != fileDeliveryModel.Id)
            {
                return BadRequest();
            }

            var result = await _fileDeliveryService.UpdateFileDeliveryModelAsync(fileDeliveryModel);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFileDeliveryModelAsync(int id)
        {
            var result = await _fileDeliveryService.DeleteFileDeliveryModelAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendFileDeliveryAsync(FileDeliveryModel fileDeliveryModel)
        {
            var result = await _fileDeliveryService.SendFileDeliveryAsync(fileDeliveryModel);
            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
