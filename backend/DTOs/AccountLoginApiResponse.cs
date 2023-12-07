namespace backend.DTOs;

public struct AccountLoginApiResponse
{
    /// <summary>
    /// The token to use for authentication.
    /// Send this back as a Bearer token in the Authorization header.
    /// </summary>
    public string Token { get; set; }
}
