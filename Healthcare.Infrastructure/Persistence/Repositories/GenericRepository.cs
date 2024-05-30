﻿using Healthcare.Application.Interfaces;
using Healthcare.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Healthcare.Infrastructure.Persistence.Repositories;
public class GenericRepository<TEntity>(ApplicationDbContext context) : IGenericRepository<TEntity>
    where TEntity : BaseEntity
{
    public void Create(TEntity entity) => context.Set<TEntity>().Add(entity);

    public void Delete(TEntity entity) => context.Remove(entity);

    public async Task<IEnumerable<TEntity>> GetAllAsync()
        => await context.Set<TEntity>().ToListAsync();

    public async Task<TEntity> GetByIdAsync(string id)
        => await context.Set<TEntity>().FindAsync(id) ?? default!;

    public void Update(TEntity entity) => context.Update(entity);
}
