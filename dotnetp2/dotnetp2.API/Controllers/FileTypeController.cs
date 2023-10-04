using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetp2.DTO;
using dotnetp2.Service;
using Microsoft.AspNetCore.Mvc;

namespace dotnetp2.API
{
    [ApiController]
    [Route("[controller]")]
    public class FileTypeController : ControllerBase
    {
        private readonly IFileTypeRepository _fileTypeRepository;
        public FileTypeController(IFileTypeRepository fileTypeRepository)
        {
            _fileTypeRepository = fileTypeRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<FileTypeModel>> GetFileTypes()
        {
            return await _fileTypeRepository.GetFileTypes();
        }
    }
}