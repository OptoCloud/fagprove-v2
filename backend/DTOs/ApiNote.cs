using backend.Database.Models;

namespace backend.DTOs;

public class ApiNote
{
    public ApiNote(NoteEntity projectEntity)
    {
        Id = projectEntity.Id;
        Title = projectEntity.Title;
        Content = projectEntity.Content;
        CreatedAt = projectEntity.CreatedAt;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
}
