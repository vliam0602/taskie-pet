using System;
using System.Data;
using TaskiePet.Application.Common;
using TaskiePet.Application.Constants;
using TaskiePet.Application.Repositories.Abstraction;
using TaskiePet.Application.Services.Abstraction;
using TaskiePet.Domain.Entities;

namespace TaskiePet.Application.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task CreateNewAccountAsync(string email, string password)
    {
        if (await userRepository.IsEmailExistsAsync(email))
        {
            throw new DuplicateNameException(ErrorMessages.DuplicateEmail);
        }
        var user = new User
        {
            Email = email,
            PasswordHash = password.Hash()
        };
        await userRepository.AddAsync(user);
    }

    public async Task<User?> GetUserByEmailAndPasswordAsync(string email, string password)
    {
        var user = await userRepository.GetByEmailAsync(email);
        if (user == null || !password.Verify(user.PasswordHash))
        {
            return null;
        }
        return user;
    }
}
