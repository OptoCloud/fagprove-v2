namespace backend.DTOs;

public struct AccountLoginApiRequest
{
    /// <summary>
    /// The username or email of the user.
    /// </summary>
    public string UsernameOrEmail { get; set; }

    /// <summary>
    /// The password of the user.
    /// </summary>
    public string Password { get; set; }
}