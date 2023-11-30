namespace backend.DTOs;

public struct AccountLoginApiRequest
{
    public string UsernameOrEmail { get; set; }
    public string Password { get; set; }
}