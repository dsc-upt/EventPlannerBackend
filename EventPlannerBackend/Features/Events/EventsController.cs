using EventPlannerBackend.Base.Controllers;
using EventPlannerBackend.Base.Repositories;

namespace EventPlannerBackend.Features.Events;

public class EventsController : CrudApiController<Event, EventResponse>
{
    public EventsController(IRepository<Event> repo) : base(repo)
    {
    }
}
