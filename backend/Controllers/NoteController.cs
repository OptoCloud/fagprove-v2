﻿using backend.Database.Models;
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

    /// <summary>
    /// Get a list of all notes for the current user.
    /// </summary>
    /// <returns></returns>
    [HttpGet("list")]
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

    /// <summary>
    /// Get a note by its ID.
    /// </summary>
    /// <param name="noteId"></param>
    /// <returns></returns>
    [HttpGet("{noteId}")]
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

    /// <summary>
    /// Create a new note.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("create")]
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

    /// <summary>
    /// Update a note by its ID.
    /// </summary>
    /// <param name="noteId">The ID of the note to update.</param>
    /// <param name="request">The request containing the new note data. (Only the fields that are not null will be updated.)</param>
    /// <returns></returns>
    [HttpPut("{noteId}")]
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

    /// <summary>
    /// Delete a note by its ID.
    /// </summary>
    /// <param name="noteId"></param>
    /// <returns></returns>
    [HttpDelete("{noteId}")]
    [Produces(Text.Plain)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> DeleteNote([FromRoute] Guid noteId)
    {
        var user = (UserEntity?)HttpContext.Items["User"];
        if (user == null)
        {
            return Unauthorized("Authentication required");
        }

        var note = await _noteService.GetNoteAsync(noteId);
        if (note == null)
        {
            return NotFound("Note not found");
        }
        if (note.UserId != user.Id)
        {
            return Forbid("You do not have access to this note");
        }

        var result = await _noteService.DeleteNoteAsync(noteId);

        return result.Match<IActionResult>(result => Ok("Note deleted"), err => BadRequest(err));
    }

    /// <summary>
    /// Update the directory of a note by its ID.
    /// </summary>
    /// <param name="noteId"></param>
    /// <param name="request"></param>
    /// <param name="_directoryService"></param>
    /// <returns></returns>
    [HttpPut("{noteId}/directory")]
    [Produces(Application.Json)]
    [ProducesResponseType(typeof(ApiNote), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateNoteDirectory([FromRoute] Guid noteId, [FromBody] ApiNoteUpdateDirectoryRequest request, [FromServices] IDirectoryService _directoryService)
    {
        var user = (UserEntity?)HttpContext.Items["User"];
        if (user == null)
        {
            return Unauthorized();
        }

        var note = await _noteService.GetNoteAsync(noteId);
        if (note == null)
        {
            return NotFound();
        }
        if (note.UserId != user.Id)
        {
            return Forbid();
        }

        Guid directoryId;

        // If the directory name is null, we want to remove the note from the directory
        if (request.DirectoryName == null)
        {
            directoryId = Guid.Empty;
        }
        else
        {
            // Otherwise, we want to get or create the directory with the given name
            var directory = await _directoryService.GetOrCreateDirectoryAsync(request.DirectoryName);

            directoryId = directory.Id;
        }

        var updateResult = await _noteService.UpdateNoteAsync(noteId, noteId => noteId.DirectoryId = directoryId);

        return updateResult.Match<IActionResult>(note => Ok(new ApiNote(note)), err => BadRequest(err));
    }
}