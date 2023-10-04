public interface IFileDeliveryService
{
    Task<IEnumerable<FileDeliveryModel>> GetAllFileDeliveryModelsAsync();
    Task<FileDeliveryModel> GetFileDeliveryModelByIdAsync(int id);
    Task<int> AddFileDeliveryModelAsync(FileDeliveryModel fileDeliveryModel);
    Task<bool> UpdateFileDeliveryModelAsync(FileDeliveryModel fileDeliveryModel);
    Task<bool> DeleteFileDeliveryModelAsync(int id);
    Task<bool> SendFileDeliveryAsync(FileDeliveryModel fileDeliveryModel);
}