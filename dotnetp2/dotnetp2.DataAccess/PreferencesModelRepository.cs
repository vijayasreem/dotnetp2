using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using dotnetp2.DTO;

namespace dotnetp2.Repository
{
    public class PreferencesModelRepository : IPreferencesModelRepository
    {
        private readonly string _connectionString;

        public PreferencesModelRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<PreferencesModel>> GetAllAsync()
        {
            using (var context = new DbContext(_connectionString))
            {
                return await context.PreferencesModels.ToListAsync();
            }
        }

        public async Task<PreferencesModel> GetByIdAsync(int id)
        {
            using (var context = new DbContext(_connectionString))
            {
                return await context.PreferencesModels.FirstOrDefaultAsync(p => p.Id == id);
            }
        }

        public async Task AddAsync(PreferencesModel preferencesModel)
        {
            using (var context = new DbContext(_connectionString))
            {
                context.PreferencesModels.Add(preferencesModel);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(PreferencesModel preferencesModel)
        {
            using (var context = new DbContext(_connectionString))
            {
                context.PreferencesModels.Update(preferencesModel);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var context = new DbContext(_connectionString))
            {
                var preferencesModel = await context.PreferencesModels.FirstOrDefaultAsync(p => p.Id == id);
                if (preferencesModel != null)
                {
                    context.PreferencesModels.Remove(preferencesModel);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}