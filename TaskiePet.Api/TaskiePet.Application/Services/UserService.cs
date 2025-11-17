using System;
using System.Data;
using TaskiePet.Application.Common;
using TaskiePet.Application.Constants;
using TaskiePet.Application.DTOs;
using TaskiePet.Application.Repositories.Abstraction;
using TaskiePet.Application.Services.Abstraction;
using TaskiePet.Domain.Entities;

namespace TaskiePet.Application.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task CreateNewAccountAsync(UserCredentialDto dto)
    {
        if (await userRepository.IsEmailExistsAsync(dto.Email))
        {
            throw new DuplicateNameException(ErrorMessages.DuplicateEmail);
        }
        var user = new User
        {
            Email = dto.Email,
            PasswordHash = dto.Password.Hash()
        };
        await userRepository.AddAsync(user);
    }

    public async Task<User?> GetUserByEmailAndPasswordAsync(UserCredentialDto dto)
    {
        var user = await userRepository.GetByEmailAsync(dto.Email);
        if (user == null || !dto.Password.Verify(user.PasswordHash))
        {
            return null;
        }
        return user;
    }
}
