using System;
using Microsoft.EntityFrameworkCore;
using TaskiePet.Application.Repositories.Abstraction;
using TaskiePet.Domain.Entities;
using TaskiePet.Infrastructure.Database;

namespace TaskiePet.Infrastructure.Repositories;

public class UserRepository(AppDbContext dbContext)
    : GenericRepository<User>(dbContext), IUserRepository
{
    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<bool> IsEmailExistsAsync(string email)
    {
        return await _dbContext.Users.AnyAsync(x => x.Email == email);
    }
}
