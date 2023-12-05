using backend.Database.Models;
using backend.DTOs;
using OneOf;

namespace backend.Services;

public interface INoteService
{
    public Task<NoteEntity?> GetNoteAsync(Guid noteId);

    public Task<List<NoteEntity>> GetNotesByUserIdAsync(Guid userId);

    public Task<OneOf<NoteEntity, ApiError>> CreateNoteAsync(Guid ownerUserId, string title, string content);

    public Task<OneOf<NoteEntity, ApiError>> UpdateNoteAsync(Guid noteId, Action<NoteEntity> modifyAction);

    public Task<OneOf<NoteEntity, ApiError>> DeleteNoteAsync(Guid noteId);
}
