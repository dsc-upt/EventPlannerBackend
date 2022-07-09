using EventPlannerBackend.Base.Models;

namespace EventPlannerBackend.Base.Repositories;

public interface IRepository<TEntity> where TEntity : Entity
{
    Task<TEntity> Add(TEntity entity);
    Task<TEntity> Update(TEntity entity);
    Task<TEntity?> Remove(TEntity entity);
    Task<TEntity?> Remove(string id);
    Task<TEntity?> Get(string id);
    IQueryable<TEntity> Get();
    Task<IEnumerable<TEntity>> GetList();
}
