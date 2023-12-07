using backend.Database;
using backend.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services;

public class DirectoryService : IDirectoryService
{
    public readonly DatabaseContext _dbContext;
    private readonly ILogger<DirectoryService> _logger;

    public DirectoryService(DatabaseContext dbContext, ILogger<DirectoryService> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<DirectoryEntity> GetOrCreateDirectoryAsync(string title)
    {
        var directory = await _dbContext.Directories.FirstOrDefaultAsync(e => e.Title == title);
        if (directory != null)
        {
            return directory;
        }

        var inserted = await _dbContext.Directories.AddAsync(new DirectoryEntity
        {
            Title = title
        });

        await _dbContext.SaveChangesAsync();

        return inserted.Entity;
    }
}
