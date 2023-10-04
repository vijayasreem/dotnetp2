using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetp2.DTO;
using dotnetp2.DataAccess;

namespace dotnetp2.Service
{
    public class PreferencesService : IPreferencesService
    {
        private readonly IPreferencesModelRepository _repository;

        public PreferencesService(IPreferencesModelRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PreferencesModel>> GetAllPreferences()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<PreferencesModel> GetPreferenceById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddPreference(PreferencesModel preferencesModel)
        {
            await _repository.AddAsync(preferencesModel);
        }

        public async Task UpdatePreference(PreferencesModel preferencesModel)
        {
            await _repository.UpdateAsync(preferencesModel);
        }

        public async Task DeletePreference(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}