public interface IFileTypeRepository
{
    Task<IEnumerable<FileTypeModel>> GetFileTypes();
}