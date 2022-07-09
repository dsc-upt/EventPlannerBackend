using EventPlannerBackend.Base.Models;
using EventPlannerBackend.Data;
using Microsoft.EntityFrameworkCore;

namespace EventPlannerBackend.Base.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    protected readonly DbContext DbContext;
    protected readonly DbSet<TEntity> DbSet;

    public Repository(ApplicationDbContext dbDbContext)
    {
        DbContext = dbDbContext;
        DbSet = dbDbContext.Set<TEntity>();
    }

    public async Task<TEntity> Add(TEntity entity)
    {
        entity.Id = Guid.NewGuid().ToString();
        entity.Created = DateTime.UtcNow;
        entity.Updated = DateTime.UtcNow;
        var result = await DbSet.AddAsync(entity);
        await Save();
        return result.Entity;
    }

    public async Task<TEntity> Update(TEntity entity)
    {
        entity.Updated = DateTime.UtcNow;
        var result = DbSet.Update(entity);
        await Save();
        return result.Entity;
    }

    public async Task<TEntity?> Remove(TEntity entity)
    {
        var result = DbSet.Remove(entity);
        await Save();
        return result.Entity;
    }

    public async Task<TEntity?> Remove(string id)
    {
        var entity = await Get(id);
        if (entity is null)
        {
            return null;
        }

        return await Remove(entity);
    }

    public async Task<TEntity?> Get(string id)
    {
        return await DbSet.FindAsync(id);
    }

    public IQueryable<TEntity> Get()
    {
        return DbSet.AsQueryable();
    }

    public async Task<IEnumerable<TEntity>> GetList()
    {
        return await DbSet.ToListAsync();
    }

    public Task Save()
    {
        return DbContext.SaveChangesAsync();
    }
}
