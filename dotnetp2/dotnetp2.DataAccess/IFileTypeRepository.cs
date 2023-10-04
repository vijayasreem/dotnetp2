namespace dotnetp2.Service
{
    public interface IFileTypeRepository
    {
        Task<IEnumerable<FileTypeModel>> GetFileTypes();
    }
}