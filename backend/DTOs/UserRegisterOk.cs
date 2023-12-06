using backend.Database.Models;

namespace backend.DTOs;

public struct UserRegisterOk
{
    public required UserEntity User { get; set; }
}
