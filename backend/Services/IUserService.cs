﻿using backend.Database.Models;
using backend.DTOs;
using OneOf;

namespace backend.Services;

public interface IUserService
{
    /// <summary>
    /// Returns a user if the registration was successful, otherwise returns a error DTO containing the error message
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public Task<OneOf<UserRegisterOk, UserRegisterConflict>> Register(AccountRegisterApiRequest request);

    /// <summary>
    /// Returns a authentication token if the login was successful, otherwise returns a error DTO containing the error message
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public Task<OneOf<UserLoginOk, UserLoginUnauthroized>> Login(AccountLoginApiRequest request);

    /// <summary>
    /// Returns a user if the token is valid, otherwise returns a error DTO containing the error message
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    public Task<OneOf<UserEntity, GenericError>> GetUserByTokenAsync(string token);
}
