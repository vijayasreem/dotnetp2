
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetp2.DTO;

namespace dotnetp2.Service
{
    public interface IPreferencesService
    {
        Task<List<PreferencesModel>> GetAllPreferences();
        Task<PreferencesModel> GetPreferenceById(int id);
        Task AddPreference(PreferencesModel preferencesModel);
        Task UpdatePreference(PreferencesModel preferencesModel);
        Task DeletePreference(int id);
    }
}
