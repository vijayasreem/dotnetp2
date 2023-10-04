using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetp2.DataAccess;
using dotnetp2.DTO;

namespace dotnetp2.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerDataAccess _customerDataAccess;

        public CustomerService(ICustomerDataAccess customerDataAccess)
        {
            _customerDataAccess = customerDataAccess;
        }

        public async Task<int> CreateAsync(CustomerModel customer)
        {
            return await _customerDataAccess.CreateAsync(customer);
        }

        public async Task<CustomerModel> GetByIdAsync(int id)
        {
            return await _customerDataAccess.GetByIdAsync(id);
        }

        public async Task<List<CustomerModel>> GetAllAsync()
        {
            return await _customerDataAccess.GetAllAsync();
        }

        public async Task<bool> UpdateAsync(CustomerModel customer)
        {
            return await _customerDataAccess.UpdateAsync(customer);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _customerDataAccess.DeleteAsync(id);
        }
    }
}