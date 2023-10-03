using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetp2.DataAccess;
using dotnetp2.DTO;

namespace dotnetp2.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<UserModel> GetByIdAsync(int id)
        {
            return await userRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            return await userRepository.GetAllAsync();
        }

        public async Task<int> CreateAsync(UserModel user)
        {
            return await userRepository.CreateAsync(user);
        }

        public async Task<bool> UpdateAsync(UserModel user)
        {
            return await userRepository.UpdateAsync(user);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await userRepository.DeleteAsync(id);
        }
    }
}