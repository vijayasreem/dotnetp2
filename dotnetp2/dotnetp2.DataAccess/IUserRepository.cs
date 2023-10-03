


using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetp2.DTO;

namespace dotnetp2.Service
{
    public interface IUserRepository
    {
        Task<UserModel> GetByIdAsync(int id);
        Task<IEnumerable<UserModel>> GetAllAsync();
        Task<int> CreateAsync(UserModel user);
        Task<bool> UpdateAsync(UserModel user);
        Task<bool> DeleteAsync(int id);
    }
}
