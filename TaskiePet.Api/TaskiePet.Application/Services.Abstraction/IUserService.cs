using System;
using TaskiePet.Domain.Entities;

namespace TaskiePet.Application.Services.Abstraction;

public interface IUserService
{
    Task<User?> GetUserByEmailAndPasswordAsync(string email, string password);
    Task CreateNewAccountAsync(string email, string password);
}
