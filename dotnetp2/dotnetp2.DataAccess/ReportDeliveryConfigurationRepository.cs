using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace dotnetp2
{
    public class ReportDeliveryConfigurationRepository : IReportDeliveryConfigurationService
    {
        private readonly string _connectionString;

        public ReportDeliveryConfigurationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<ReportDeliveryConfigurationModel>> GetAllAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand("SELECT * FROM ReportDeliveryConfiguration", connection);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    var configurations = new List<ReportDeliveryConfigurationModel>();

                    while (reader.Read())
                    {
                        var configuration = new ReportDeliveryConfigurationModel
                        {
                            DestinationType = (DestinationType)reader.GetInt32(reader.GetOrdinal("DestinationType")),
                            DestinationAddress = reader.GetString(reader.GetOrdinal("DestinationAddress"))
                        };

                        configurations.Add(configuration);
                    }

                    return configurations;
                }
            }
        }

        public async Task<ReportDeliveryConfigurationModel> GetByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand("SELECT * FROM ReportDeliveryConfiguration WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        var configuration = new ReportDeliveryConfigurationModel
                        {
                            DestinationType = (DestinationType)reader.GetInt32(reader.GetOrdinal("DestinationType")),
                            DestinationAddress = reader.GetString(reader.GetOrdinal("DestinationAddress"))
                        };

                        return configuration;
                    }

                    return null;
                }
            }
        }

        public async Task<int> AddAsync(ReportDeliveryConfigurationModel configuration)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand("INSERT INTO ReportDeliveryConfiguration (DestinationType, DestinationAddress) " +
                                             "VALUES (@DestinationType, @DestinationAddress); SELECT SCOPE_IDENTITY();", connection);
                command.Parameters.AddWithValue("@DestinationType", (int)configuration.DestinationType);
                command.Parameters.AddWithValue("@DestinationAddress", configuration.DestinationAddress);

                var newId = await command.ExecuteScalarAsync();
                return int.Parse(newId.ToString());
            }
        }

        public async Task UpdateAsync(ReportDeliveryConfigurationModel configuration)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand("UPDATE ReportDeliveryConfiguration " +
                                             "SET DestinationType = @DestinationType, DestinationAddress = @DestinationAddress " +
                                             "WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@DestinationType", (int)configuration.DestinationType);
                command.Parameters.AddWithValue("@DestinationAddress", configuration.DestinationAddress);
                command.Parameters.AddWithValue("@Id", configuration.Id);

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand("DELETE FROM ReportDeliveryConfiguration WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                await command.ExecuteNonQueryAsync();
            }
        }
    }
}