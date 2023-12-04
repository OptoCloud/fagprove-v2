namespace backend.DTOs;

public class ApiNoteUpdateRequest
{
    public required string? Title { get; set; }
    public required string? Content { get; set; }
}