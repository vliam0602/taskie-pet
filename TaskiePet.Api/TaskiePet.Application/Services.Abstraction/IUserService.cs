using System;
using TaskiePet.Application.DTOs;
using TaskiePet.Domain.Entities;

namespace TaskiePet.Application.Services.Abstraction;

public interface IUserService
{
    Task<User?> GetUserByEmailAndPasswordAsync(UserCredentialDto dto);
    Task CreateNewAccountAsync(UserCredentialDto dto);
}
