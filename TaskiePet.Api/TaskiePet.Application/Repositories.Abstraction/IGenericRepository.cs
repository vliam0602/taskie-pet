using System;
using TaskiePet.Domain.Common;

namespace TaskiePet.Application.Repositories.Abstraction;

public interface IGenericRepository<T> where T : BaseEntity
{
    // Task<T?> GetByIdAsync(Guid id);
    // Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    // void Update(T entity);
    // Task DeleteAsync(Guid id);
    // Task<bool> IsExistAsync(Guid id);
}
