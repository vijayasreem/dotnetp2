public class FileTypeRepository : IFileTypeRepository
{
    private readonly IDbConnection _dbConnection;

    public FileTypeRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<FileTypeModel>> GetFileTypes()
    {
        var sql = "SELECT Id, Label, Value FROM FileType";
        var fileTypes = await _dbConnection.QueryAsync<FileTypeModel>(sql);
        return fileTypes;
    }
}