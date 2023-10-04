


using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetp2.DTO;

namespace dotnetp2.Service
{
    public interface IPreferencesModelRepository
    {
        Task<List<PreferencesModel>> GetAllAsync();
        Task<PreferencesModel> GetByIdAsync(int id);
        Task AddAsync(PreferencesModel preferencesModel);
        Task UpdateAsync(PreferencesModel preferencesModel);
        Task DeleteAsync(int id);
    }
}
