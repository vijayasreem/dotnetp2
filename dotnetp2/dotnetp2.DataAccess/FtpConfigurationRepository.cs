();
            }
        }
    }
}

public class FtpConfigurationRepository : IFtpConfigurationRepository
{
    private readonly SqlConnection connection;
    private string connectionString;

    public FtpConfigurationRepository(string connectionString)
    {
        this.connectionString = connectionString;
        this.connection = new SqlConnection(connectionString);
    }
    
    public async Task<int> CreateAsync(FtpConfigurationModel model)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "INSERT INTO FtpConfiguration (FtpUrl, Credential, FilePath) VALUES (@FtpUrl, @Credential, @FilePath); SELECT CAST(scope_identity() AS int)";
        cmd.Parameters.AddWithValue("@FtpUrl", model.FtpUrl);
        cmd.Parameters.AddWithValue("@Credential", model.Credential);
        cmd.Parameters.AddWithValue("@FilePath", model.FilePath);
        cmd.CommandType = CommandType.Text;
        cmd.Connection = connection;

        try
        {
            connection.Open();
            int newId = (int)await cmd.ExecuteScalarAsync();
            model.Id = newId;
            return newId;
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            connection.Close();
        }
    }

    public async Task<FtpConfigurationModel> ReadAsync(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT * FROM FtpConfiguration WHERE Id = @Id";
        cmd.Parameters.AddWithValue("@Id", id);
        cmd.CommandType = CommandType.Text;
        cmd.Connection = connection;

        try
        {
            connection.Open();
            SqlDataReader reader = await cmd.ExecuteReaderAsync();

            FtpConfigurationModel model = null;
            if (reader.HasRows)
            {
                reader.Read();
                model = new FtpConfigurationModel()
                {
                    Id = (int)reader["Id"],
                    FtpUrl = (string)reader["FtpUrl"],
                    Credential = (string)reader["Credential"],
                    FilePath = (string)reader["FilePath"]
                };
            }
            return model;
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            connection.Close();
        }
    }

    public async Task<bool> UpdateAsync(FtpConfigurationModel model)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "UPDATE FtpConfiguration SET FtpUrl = @FtpUrl, Credential = @Credential, FilePath = @FilePath WHERE Id = @Id";
        cmd.Parameters.AddWithValue("@FtpUrl", model.FtpUrl);
        cmd.Parameters.AddWithValue("@Credential", model.Credential);
        cmd.Parameters.AddWithValue("@FilePath", model.FilePath);
        cmd.Parameters.AddWithValue("@Id", model.Id);
        cmd.CommandType = CommandType.Text;
        cmd.Connection = connection;

        try
        {
            connection.Open();
            await cmd.ExecuteNonQueryAsync();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            connection.Close();
        }
    }


    public async Task<bool> DeleteAsync(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "DELETE FROM FtpConfiguration WHERE Id = @Id";
        cmd.Parameters.AddWithValue("@Id", id);
        cmd.CommandType = CommandType.Text;
        cmd.Connection = connection;

        try
        {
            connection.Open();
            await cmd.ExecuteNonQueryAsync();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            connection.Close();
        }
    }
}