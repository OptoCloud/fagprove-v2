using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Register a new user.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("register")]
    [Produces(Text.Plain)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Register([FromBody] AccountRegisterApiRequest request)
    {
        var result = await _userService.Register(request);

        // Map the result to an IActionResult
        return result.Match<IActionResult>(dto => Ok("User created"), dto => Conflict("Username or email already exists"));
    }

    /// <summary>
    /// Login a user.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("login")]
    [Produces(Application.Json)]
    [ProducesResponseType(typeof(AccountLoginApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login([FromBody] AccountLoginApiRequest request)
    {
        var result = await _userService.Login(request);

        // Map the result to an IActionResult
        return result.Match<IActionResult>(dto => Ok(new AccountLoginApiResponse { Token = dto.AuthToken }), dto => Unauthorized("Invalid username or password"));
    }
}