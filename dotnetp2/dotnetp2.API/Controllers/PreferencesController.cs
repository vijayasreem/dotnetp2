


using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetp2.DTO;
using dotnetp2.Service;
using Microsoft.AspNetCore.Mvc;

namespace dotnetp2.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreferencesController : ControllerBase
    {
        private readonly IPreferencesService _preferencesService;

        public PreferencesController(IPreferencesService preferencesService)
        {
            _preferencesService = preferencesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PreferencesModel>>> GetAllPreferences()
        {
            var preferences = await _preferencesService.GetAllPreferences();
            return Ok(preferences);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PreferencesModel>> GetPreferenceById(int id)
        {
            var preference = await _preferencesService.GetPreferenceById(id);
            if (preference == null)
            {
                return NotFound();
            }
            return Ok(preference);
        }

        [HttpPost]
        public async Task<ActionResult> AddPreference(PreferencesModel preferencesModel)
        {
            await _preferencesService.AddPreference(preferencesModel);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePreference(int id, PreferencesModel preferencesModel)
        {
            if (id != preferencesModel.Id)
            {
                return BadRequest();
            }

            await _preferencesService.UpdatePreference(preferencesModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePreference(int id)
        {
            await _preferencesService.DeletePreference(id);
            return Ok();
        }
    }
}
