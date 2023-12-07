using backend.Database.Models;

namespace backend.Services;

public interface IDirectoryService
{
    /// <summary>
    /// Get or create a directory with the given name
    /// </summary>
    /// <param name="title"></param>
    /// <returns></returns>
    Task<DirectoryEntity> GetOrCreateDirectoryAsync(string title);
}
