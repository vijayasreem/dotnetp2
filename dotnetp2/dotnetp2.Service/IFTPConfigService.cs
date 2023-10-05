public interface IFTPConfigService
{
    Task<bool> ConfigureFTP(string ftpUrl, string password, string filePath);
}