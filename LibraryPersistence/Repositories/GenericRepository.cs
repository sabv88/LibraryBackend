﻿using LibraryApplication.Repositories;
using LibraryDomain.Common;
using Microsoft.EntityFrameworkCore;

namespace LibraryPersistence.Repositories
{
    namespace CleanArchitectureDemo.Persistence.Repositories
    {
        public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
        {
            private readonly LibraryDbContext _dbContext;

            public GenericRepository(LibraryDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public IQueryable<T> Entities => _dbContext.Set<T>();

            public async Task<T> AddAsync(T entity)
            {
                await _dbContext.Set<T>().AddAsync(entity);
                return entity;
            }

            public Task UpdateAsync(T entity)
            {
                T exist = _dbContext.Set<T>().Find(entity.Id);
                _dbContext.Entry(exist).CurrentValues.SetValues(entity);
                return Task.CompletedTask;
            }

            public Task DeleteAsync(T entity)
            {
                _dbContext.Set<T>().Remove(entity);
                return Task.CompletedTask;
            }

            public async Task<List<T>> GetAllAsync()
            {
                return await _dbContext
                    .Set<T>()
                    .ToListAsync();
            }

            public async Task<T> GetByIdAsync(Guid id)
            {
                return await _dbContext.Set<T>().FindAsync(id);
            }
        }
    }
}
