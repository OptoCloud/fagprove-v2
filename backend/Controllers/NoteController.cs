using backend.Database.Models;
using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class NoteController : ControllerBase
{
    private readonly INoteService _noteService;

    public NoteController(INoteService projectService)
    {
        _noteService = projectService;
    }

    [HttpGet("/list")]
    [Produces(Application.Json)]
    [ProducesResponseType(typeof(List<ApiNote>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> ListNotes()
    {
        var user = (UserEntity?)HttpContext.Items["User"];
        if (user == null)
        {
            return Unauthorized("Authentication required");
        }

        var notes = await _noteService.GetNotesByUserIdAsync(user.Id);

        return Ok(notes.Select(note => new ApiNote(note)));
    }

    [HttpGet("/{noteId}")]
    [Produces(Application.Json)]
    [ProducesResponseType(typeof(ApiNote), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetNote([FromRoute] Guid noteId)
    {
        var user = (UserEntity?)HttpContext.Items["User"];
        if (user == null)
        {
            return Unauthorized("Authentication required");
        }

        var result = await _noteService.GetNoteAsync(noteId);
        if (result == null)
        {
            return NotFound("Note not found");
        }
        if (result.UserId != user.Id)
        {
            return Forbid("You do not have access to this note");
        }

        return Ok(new ApiNote(result));
    }

    [HttpPost("/create")]
    [Produces(Application.Json)]
    [ProducesResponseType(typeof(ApiNote), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateNote([FromBody] ApiNoteCreateRequest request)
    {
        var user = (UserEntity?)HttpContext.Items["User"];
        if (user == null)
        {
            return Unauthorized("Authentication required");
        }

        var result = await _noteService.CreateNoteAsync(user.Id, request.Title, request.Content);

        return result.Match<IActionResult>(note => Ok(new ApiNote(note)), err => BadRequest(err));
    }

    [HttpPut("/{noteId}")]
    [Produces(Application.Json)]
    [ProducesResponseType(typeof(ApiNote), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateNote([FromRoute] Guid noteId, [FromBody] ApiNoteUpdateRequest request)
    {
        var user = (UserEntity?)HttpContext.Items["User"];
        if (user == null)
        {
            return Unauthorized("Authentication required");
        }

        var result = await _noteService.UpdateNoteAsync(noteId, note =>
        {
            if (note.UserId != user.Id)
            {
                return;
            }

            if (request.Title != null)
            {
                note.Title = request.Title;
            }
            if (request.Content != null)
            {
                note.Content = request.Content;
            }
        });

        return result.Match<IActionResult>(note => Ok(new ApiNote(note)), err => BadRequest(err));
    }
    /*
    [HttpPut("/{noteId}/directory")]
    public async Task<IActionResult> UpdateNoteDirectory([FromRoute] Guid noteId, [FromBody] ApiNoteUpdateDirectoryRequest request)
    {
        var user = (UserEntity?)HttpContext.Items["User"];
        if (user == null)
        {
            return Unauthorized();
        }

        var result = await _noteService.UpdateNoteAsync(noteId, note => note.DirectoryId = request.DirectoryId);

        return result.Match<IActionResult>(note => Ok(new ApiNote(note)), err => BadRequest(err));
    }

    [HttpDelete("/{noteId}")]
    public async Task<IActionResult> DeleteNote([FromRoute] Guid noteId)
    {
        var user = (UserEntity?)HttpContext.Items["User"];
        if (user == null)
        {
            return Unauthorized();
        }

        var result = await _noteService.DeleteNoteAsync(noteId, user.Id);

        return result.Match<IActionResult>(note => Ok(new ApiNote(note)), err => BadRequest(err));
    }
    */
}