public class SendEmailRepository : ISendEmailRepository
{
    private string _connectionString;

    public SendEmailRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<SendEmailModel> GetSendEmailModelAsync(int id)
    {
        using (var conn = new SqlConnection(_connectionString))
        {
            conn.Open();

            var command = new SqlCommand("SELECT * FROM SendEmail WHERE Id = @Id", conn);
            command.Parameters.AddWithValue("@Id", id);

            var reader = await command.ExecuteReaderAsync();
            if (reader.Read())
            {
                var model = new SendEmailModel
                {
                    Id = reader.GetInt32(0),
                    AttachedFile = reader.GetFile(1),
                    FileType = reader.GetString(2),
                    DestinationType = reader.GetString(3),
                    ScheduleTime = reader.GetInt32(4),
                    RequestsInformation = reader.GetDataTable(5)
                };

                return model;
            }

            return null;
        }
    }

    public async Task<bool> SendEmailAsync(SendEmailModel model)
    {
        // Send email logic
        // ...

        return true;
    }

    public async Task<bool> SendFilesToFTPAsync(SendEmailModel model)
    {
        // Send files to FTP logic
        // ...

        return true;
    }

    public async Task<bool> SendFilesToSharepointAsync(SendEmailModel model)
    {
        // Send files to Sharepoint logic
        // ...

        return true;
    }
}