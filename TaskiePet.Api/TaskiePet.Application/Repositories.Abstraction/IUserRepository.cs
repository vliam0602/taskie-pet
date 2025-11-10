using System;
using TaskiePet.Domain.Entities;

namespace TaskiePet.Application.Repositories.Abstraction;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
    Task<bool> IsEmailExistsAsync(string email);
}
