}
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}

public interface IEmailService
{
    Task<bool> SendSmtpEmailAsync(string from, string to, string subject, string body, string attachmentPath);
    Task<bool> SendFileToFTPAsync(string sourceFilePath, string destinationFilePath);
    Task<bool> SendFileToSharepointAsync(string sourceFilePath, string destinationFilePath);
    Task<bool> ProcessRequestsAsync();
}