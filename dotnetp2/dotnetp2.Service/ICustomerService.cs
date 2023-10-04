using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetp2.DTO;

namespace dotnetp2.Service
{
    public interface ICustomerService
    {
        Task<int> CreateAsync(CustomerModel customer);
        Task<CustomerModel> GetByIdAsync(int id);
        Task<List<CustomerModel>> GetAllAsync();
        Task<bool> UpdateAsync(CustomerModel customer);
        Task<bool> DeleteAsync(int id);
    }
}