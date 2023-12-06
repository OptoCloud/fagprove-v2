using backend.Database.Models;
using backend.DTOs;
using OneOf;

namespace backend.Services;

public interface INoteService
{
    /// <summary>
    /// Get a note by its ID
    /// </summary>
    /// <param name="noteId"></param>
    /// <returns>The note, or <c>null</c> if the note was not found</returns>
    public Task<NoteEntity?> GetNoteAsync(Guid noteId);

    /// <summary>
    /// Get all notes owned by a user
    /// </summary>
    /// <param name="userId">The ID of the user who owns the notes</param>
    /// <returns>The list of notes</returns>
    public Task<List<NoteEntity>> GetNotesByUserIdAsync(Guid userId);

    /// <summary>
    /// Create a new note
    /// </summary>
    /// <param name="ownerUserId">The ID of the user who owns the note</param>
    /// <param name="title">The title of the note</param>
    /// <param name="content">The content of the note</param>
    /// <returns>The created note, or GenericError if the title is empty</returns>
    public Task<OneOf<NoteEntity, GenericError>> CreateNoteAsync(Guid ownerUserId, string title, string content);

    /// <summary>
    /// Update a note
    /// </summary>
    /// <param name="noteId">The ID of the note to update</param>
    /// <param name="modifyAction">A function that modifies the note</param>
    /// <returns>The updated note, or GenericError if the note was not found</returns>
    public Task<OneOf<NoteEntity, GenericError>> UpdateNoteAsync(Guid noteId, Action<NoteEntity> modifyAction);

    /// <summary>
    /// Delete a note
    /// </summary>
    /// <param name="noteId">The ID of the note to delete</param>
    /// <returns><c>true</c> if the note was deleted, or GenericError if the note was not found</returns>
    public Task<OneOf<bool, GenericError>> DeleteNoteAsync(Guid noteId);
}
