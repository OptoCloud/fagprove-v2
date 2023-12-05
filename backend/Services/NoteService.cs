using backend.Database;
using backend.Database.Models;
using backend.DTOs;
using Microsoft.EntityFrameworkCore;
using OneOf;

namespace backend.Services;

public class NoteService : INoteService
{
    public readonly DatabaseContext _dbContext;
    private readonly ILogger<NoteService> _logger;

    public NoteService(DatabaseContext dbContext, ILogger<NoteService> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public Task<NoteEntity?> GetNoteAsync(Guid projectId)
    {
        return _dbContext.Notes.FirstOrDefaultAsync(e => e.Id == projectId);
    }

    public async Task<List<NoteEntity>> GetNotesByUserIdAsync(Guid userId)
    {
        return await _dbContext.Notes.Where(e => e.UserId == userId).ToListAsync();
    }

    public async Task<OneOf<NoteEntity, ApiError>> CreateNoteAsync(Guid ownerUserId, string title, string description)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return new ApiError("Title cannot be empty");
        }

        var project = new NoteEntity
        {
            UserId = ownerUserId,
            Title = title,
            Content = description
        };

        await _dbContext.Notes.AddAsync(project);
        await _dbContext.SaveChangesAsync();

        return project;
    }

    public async Task<OneOf<NoteEntity, ApiError>> UpdateNoteAsync(Guid projectId, Action<NoteEntity> modifyAction)
    {
        var project = await _dbContext.Notes.FirstOrDefaultAsync(e => e.Id == projectId);

        if (project == null)
        {
            return new ApiError("Project not found");
        }

        modifyAction(project);

        await _dbContext.SaveChangesAsync();

        return project;
    }

    public async Task<OneOf<NoteEntity, ApiError>> DeleteNoteAsync(Guid projectId)
    {
        var project = await _dbContext.Notes.FirstOrDefaultAsync(e => e.Id == projectId);

        if (project == null)
        {
            return new ApiError("Project not found");
        }

        _dbContext.Notes.Remove(project);
        await _dbContext.SaveChangesAsync();

        return project;
    }
}
