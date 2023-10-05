namespace dotnetp2.Repository
{
    public class FtpConfigurationRepository : IFtpConfigurationRepository
    {
        private readonly string _connectionString;

        public FtpConfigurationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> CreateFtpConfigurationAsync(FtpConfigurationModel model)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var cmd = new SqlCommand("INSERT INTO FtpConfiguration (FtpUrl, Password, FilePath) VALUES (@FtpUrl, @Password, @FilePath)", connection);
                cmd.Parameters.AddWithValue("@FtpUrl", model.FtpUrl);
                cmd.Parameters.AddWithValue("@Password", model.Password);
                cmd.Parameters.AddWithValue("@FilePath", model.FilePath);

                return await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task<FtpConfigurationModel> GetFtpConfigurationAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var cmd = new SqlCommand("SELECT * FROM FtpConfiguration WHERE Id = @Id", connection);
                cmd.Parameters.AddWithValue("@Id", id);

                var reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    reader.Read();
                    return new FtpConfigurationModel
                    {
                        Id = reader.GetInt32(0),
                        FtpUrl = reader.GetString(1),
                        Password = reader.GetString(2),
                        FilePath = reader.GetString(3)
                    };
                }

                return null;
            }
        }

        public async Task<int> UpdateFtpConfigurationAsync(FtpConfigurationModel model)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var cmd = new SqlCommand("UPDATE FtpConfiguration SET FtpUrl = @FtpUrl, Password = @Password, FilePath = @FilePath WHERE Id = @Id", connection);
                cmd.Parameters.AddWithValue("@FtpUrl", model.FtpUrl);
                cmd.Parameters.AddWithValue("@Password", model.Password);
                cmd.Parameters.AddWithValue("@FilePath", model.FilePath);
                cmd.Parameters.AddWithValue("@Id", model.Id);

                return await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task<int> DeleteFtpConfigurationAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var cmd = new SqlCommand("DELETE FROM FtpConfiguration WHERE Id = @Id", connection);
                cmd.Parameters.AddWithValue("@Id", id);

                return await cmd.ExecuteNonQueryAsync();
            }
        }
    }
}