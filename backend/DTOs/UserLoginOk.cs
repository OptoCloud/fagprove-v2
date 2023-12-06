using backend.Database.Models;

namespace backend.DTOs;

public struct UserLoginOk
{
    public required UserEntity User { get; set; }
    public required string AuthToken { get; set; }
}
