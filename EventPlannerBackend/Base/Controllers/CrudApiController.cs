using EventPlannerBackend.Base.Models;
using EventPlannerBackend.Base.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EventPlannerBackend.Base.Controllers;

public class CrudApiController<TEntity, TVm> : ReadonlyApiController<TEntity, TVm>
    where TEntity : Entity where TVm : ViewModel
{
    public CrudApiController(IRepository<TEntity> repo) : base(repo)
    {
    }

    /// <summary>
    ///     Does something
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<TVm>> Add(TEntity entity)
    {
        return Ok(await Repo.Add(entity));
    }
}
