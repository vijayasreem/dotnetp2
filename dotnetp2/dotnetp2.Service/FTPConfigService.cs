public class FTPConfigService : IFTPConfigService
{
    public async Task<bool> ConfigureFTP(string ftpUrl, string password, string filePath)
    {
        // Define FTP connection object
        FtpWebRequest ftpConnection = (FtpWebRequest)WebRequest.Create(ftpUrl);

        // Set FTP connection credentials
        ftpConnection.Credentials = new NetworkCredential(password);

        // Set request type
        ftpConnection.Method = WebRequestMethods.Ftp.DownloadFile;

        // Set file path
        ftpConnection.UseBinary = true;
        ftpConnection.UsePassive = true;
        ftpConnection.KeepAlive = true;
        ftpConnection.ConnectionGroupName = Guid.NewGuid().ToString();

        // Get response from FTP server
        using (FtpWebResponse response = (FtpWebResponse)ftpConnection.GetResponse())
        {
            // Create a stream from the response
            using (Stream responseStream = response.GetResponseStream())
            {
                // Create a file stream and save the file
                using (FileStream fileStream = File.Create(filePath))
                {
                    await responseStream.CopyToAsync(fileStream);
                }
            }
        }

        return true;
    }
}