using backend.DataAnnotations;

namespace backend.DTOs;

public struct AccountRegisterApiRequest
{
    /// <summary>
    /// The username of the user.
    /// </summary>
    [Username]
    public string Username { get; set; }

    /// <summary>
    /// The email of the user.
    /// </summary>
    [EmailAddress]
    public string Email { get; set; }

    /// <summary>
    /// The password of the user.
    /// </summary>
    [Password]
    public string Password { get; set; }
}