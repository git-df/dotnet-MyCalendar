using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories.Interfaces
{
    public interface IEventRepository
    {
        Task<(List<Event>, int)> GetFiltredEventsByUserId(Guid userid, DateTime fromDate, DateTime toDate, string filter, int count, int page, string orderBy);
        Task<Event> GetEventById(int eventId);
        Task<Event> EditEvent(Event updatedEvent);
        Task<Event> AddEvent(Event addedEvent);
    }
}
