using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace dotnetp2
{
    public interface IRepository
    {
        Task<T> GetByIdAsync<T>(int id) where T : class;
        Task<IEnumerable<T>> GetAllAsync<T>() where T : class;
        Task<int> CreateAsync<T>(T entity) where T : class;
        Task<int> UpdateAsync<T>(T entity) where T : class;
        Task<int> DeleteAsync<T>(int id) where T : class;
    }

    public class Repository : IRepository
    {
        private readonly string connectionString;

        public Repository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<T> GetByIdAsync<T>(int id) where T : class
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var query = $"SELECT * FROM {typeof(T).Name} WHERE Id = @Id";
                var parameters = new { Id = id };

                return await connection.QuerySingleOrDefaultAsync<T>(query, parameters);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var query = $"SELECT * FROM {typeof(T).Name}";

                return await connection.QueryAsync<T>(query);
            }
        }

        public async Task<int> CreateAsync<T>(T entity) where T : class
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var query = $"INSERT INTO {typeof(T).Name} VALUES (@Property1, @Property2)";
                var parameters = new
                {
                    Property1 = entity.Property1,
                    Property2 = entity.Property2
                };

                return await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<int> UpdateAsync<T>(T entity) where T : class
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var query = $"UPDATE {typeof(T).Name} SET Property1 = @Property1, Property2 = @Property2 WHERE Id = @Id";
                var parameters = new
                {
                    Property1 = entity.Property1,
                    Property2 = entity.Property2,
                    Id = entity.Id
                };

                return await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<int> DeleteAsync<T>(int id) where T : class
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var query = $"DELETE FROM {typeof(T).Name} WHERE Id = @Id";
                var parameters = new { Id = id };

                return await connection.ExecuteAsync(query, parameters);
            }
        }
    }

    public class EntityRepository : IRepository
    {
        private readonly Repository repository;

        public EntityRepository(string connectionString)
        {
            repository = new Repository(connectionString);
        }

        public Task<T> GetByIdAsync<T>(int id) where T : class
        {
            return repository.GetByIdAsync<T>(id);
        }

        public Task<IEnumerable<T>> GetAllAsync<T>() where T : class
        {
            return repository.GetAllAsync<T>();
        }

        public Task<int> CreateAsync<T>(T entity) where T : class
        {
            return repository.CreateAsync<T>(entity);
        }

        public Task<int> UpdateAsync<T>(T entity) where T : class
        {
            return repository.UpdateAsync<T>(entity);
        }

        public Task<int> DeleteAsync<T>(int id) where T : class
        {
            return repository.DeleteAsync<T>(id);
        }
    }
}