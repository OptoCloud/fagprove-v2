using backend.Database;
using backend.Database.Models;
using backend.DTOs;
using Microsoft.EntityFrameworkCore;
using OneOf;

namespace backend.Services;

public class UserService : IUserService
{
    public readonly DatabaseContext _dbContext;
    private readonly ILogger<UserService> _logger;

    public UserService(DatabaseContext dbContext, ILogger<UserService> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<OneOf<UserRegisterOk, UserRegisterConflict>> Register(AccountRegisterApiRequest request)
    {
        if (await _dbContext.Users.AnyAsync(e => e.Username == request.Username || e.Email == request.Email))
        {
            return new UserRegisterConflict();
        }

        var user = new UserEntity
        {
            Username = request.Username,
            Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
        };

        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return new UserRegisterOk { User = user };
    }

    public async Task<OneOf<UserLoginOk, UserLoginUnauthroized>> Login(AccountLoginApiRequest request)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(e => e.Username == request.UsernameOrEmail || e.Email == request.UsernameOrEmail);

        if (user == null)
        {
            await Task.Delay(2000); // Simulate a slow response to prevent timing attacks
            return new UserLoginUnauthroized(UserLoginUnauthroized.ReasonEnum.UserNotFound);
        }

        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
        {
            return new UserLoginUnauthroized(UserLoginUnauthroized.ReasonEnum.HashMismatch);
        }

        // Fill a 32-byte buffer with random data, and then convert it to a hex string to get a 64-character long cryptographically secure token
        string token = Utils.RandHex(64);
        string tokenHash = Utils.HashToStr(token);

        var authToken = new AuthTokenEntity
        {
            UserId = user.Id,
            TokenHash = tokenHash
        };

        await _dbContext.AuthTokens.AddAsync(authToken);
        await _dbContext.SaveChangesAsync();

        return new UserLoginOk { User = user, AuthToken = token };
    }

    public async Task<OneOf<UserEntity, GenericError>> GetUserByTokenAsync(string token)
    {
        var tokenHash = Utils.HashToStr(token);

        var authToken = await _dbContext.AuthTokens.FirstOrDefaultAsync(e => e.TokenHash == tokenHash);

        if (authToken == null)
        {
            return new GenericError("Invalid token");
        }

        var user = await _dbContext.Users.FirstOrDefaultAsync(e => e.Id == authToken.UserId);

        if (user == null)
        {
            return new GenericError("Invalid token");
        }

        return user;
    }
}
