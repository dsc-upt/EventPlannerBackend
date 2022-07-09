using EventPlannerBackend.Base.Models;
using EventPlannerBackend.Base.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EventPlannerBackend.Base.Controllers;

public class ReadonlyApiController<TEntity, TVm> : ApiController where TEntity : Entity where TVm : ViewModel
{
    protected readonly IRepository<TEntity> Repo;

    public ReadonlyApiController(IRepository<TEntity> repo)
    {
        Repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TVm>>> Get()
    {
        return Ok(await Repo.GetList());
    }
}