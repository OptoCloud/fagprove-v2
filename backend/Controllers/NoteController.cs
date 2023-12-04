﻿using backend.Database.Models;
using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult ListNotes()
    {
        var user = (UserEntity?)HttpContext.Items["User"];
        if (user == null)
        {
            return Unauthorized();
        }

        return Ok(_noteService.GetNotesByUserIdAsync(user.Id));
    }

    [HttpGet("/{noteId}")]
    public async Task<IActionResult> GetNote([FromRoute] Guid noteId)
    {
        var user = (UserEntity?)HttpContext.Items["User"];
        if (user == null)
        {
            return Unauthorized();
        }

        var result = await _noteService.GetNoteAsync(noteId);

        if (result == null || result.UserId != user.Id)
        {
            return NotFound();
        }

        return Ok(new ApiNote(result));
    }

    [HttpPost("/create")]
    public async Task<IActionResult> CreateNote([FromBody] ApiNoteCreateRequest request)
    {
        var user = (UserEntity?)HttpContext.Items["User"];
        if (user == null)
        {
            return Unauthorized();
        }

        var result = await _noteService.CreateNoteAsync(user.Id, request.Title, request.Content);

        return result.Match<IActionResult>(note => Ok(new ApiNote(note)), err => BadRequest(err));
    }

    [HttpPut("/{noteId}")]
    public async Task<IActionResult> UpdateNote([FromRoute] Guid noteId, [FromBody] ApiNoteUpdateRequest request)
    {
        var user = (UserEntity?)HttpContext.Items["User"];
        if (user == null)
        {
            return Unauthorized();
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
}