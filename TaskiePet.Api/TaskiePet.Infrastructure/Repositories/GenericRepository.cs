using System;
using Microsoft.EntityFrameworkCore;
using TaskiePet.Application.Repositories.Abstraction;
using TaskiePet.Domain.Common;
using TaskiePet.Infrastructure.Database;

namespace TaskiePet.Infrastructure.Repositories;

public class GenericRepository<T>(AppDbContext dbContext) : IGenericRepository<T>
    where T : BaseEntity
{
    protected readonly AppDbContext _dbContext = dbContext;
    protected readonly DbSet<T> _dbSet = dbContext.Set<T>();

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
        _dbContext.SaveChanges();
    }
}
