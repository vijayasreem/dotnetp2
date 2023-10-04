
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetp2.DTO;

namespace dotnetp2.Service
{
    public interface IFileDeliveryModelRepository
    {
        Task<IEnumerable<FileDeliveryModel>> GetAllAsync();
        Task<FileDeliveryModel> GetByIdAsync(int id);
        Task<int> AddAsync(FileDeliveryModel fileDeliveryModel);
        Task<bool> UpdateAsync(FileDeliveryModel fileDeliveryModel);
        Task<bool> DeleteAsync(int id);
    }
}
