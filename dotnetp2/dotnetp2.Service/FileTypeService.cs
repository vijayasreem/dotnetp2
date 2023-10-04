using dotnetp2.DataAccess;
using dotnetp2.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnetp2.Service
{
    public class FileTypeService : IFileTypeRepository
    {
        private readonly IFileTypeRepository fileTypeRepository;

        public FileTypeService(IFileTypeRepository fileTypeRepository)
        {
            this.fileTypeRepository = fileTypeRepository;
        }

        public async Task<IEnumerable<FileTypeModel>> GetFileTypes()
        {
            return await fileTypeRepository.GetFileTypes();
        }

        public async Task<IEnumerable<FileTypeModel>> GetFileTypes()
        {
            return await fileTypeRepository.GetFileTypes();
        }
    }
}