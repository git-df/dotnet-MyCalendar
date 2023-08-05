using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistance.Data;
using Persistance.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly mcContext _context;

        public EventRepository(mcContext context)
        {
            _context = context;
        }

        public async Task<Event> AddEvent(Event addedEvent)
        {
            _context.Events.Add(addedEvent);
            await _context.SaveChangesAsync();
            return addedEvent;
        }

        public async Task<Event> EditEvent(Event updatedEvent)
        {
            _context.Events.Update(updatedEvent);
            await _context.SaveChangesAsync();
            return updatedEvent;
        }

        public async Task<Event> GetEventById(int eventId)
        {
            return await _context.Events
                .Include(e => e.Comments).ThenInclude(c => c.User)
                .Include(e => e.User)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == eventId);
        }

        public async Task<(List<Event>, int)> GetFiltredEventsByUserId(Guid userid, DateTime fromDate, DateTime toDate, string filter, int count, int page, string orderBy)

        {
            var query = _context.Events
                .Include(e => e.User)
                .ThenInclude(u => u.accesRequestsToUser)
                .Where(e => (e.User.accesRequestsToUser.FirstOrDefault(a => a.FromUserId == userid && a.IsAccepted) != null) || e.UserId == userid)
                .Where(e => e.EventDate >= fromDate && e.EventDate < toDate)
                .Where(e => filter == null ||
                        e.Title.ToLower().Contains(filter.ToLower()) ||
                        e.Label.ToLower().Contains(filter.ToLower()) ||
                        (e.User.FirstName+e.User.LastName).ToLower().Contains(filter.ToLower())
                    );

            var totalCount = await query.CountAsync();

            if (!orderBy.IsNullOrEmpty())
            {
                switch (orderBy)
                {
                    case "title": query = query.OrderBy(e => e.Title); break;
                    case "title_desc": query = query.OrderByDescending(e => e.Title); break;
                    case "label": query = query.OrderBy(e => e.Label); break;
                    case "label_desc": query = query.OrderByDescending(e => e.Label); break;
                    case "description": query = query.OrderBy(e => e.Description); break;
                    case "description_desc": query = query.OrderByDescending(e => e.Description); break;
                    case "date": query = query.OrderBy(e => e.EventDate); break;
                    case "date_desc": query = query.OrderByDescending(e => e.EventDate); break;
                    case "endDate": query = query.OrderBy(e => e.EndEventDate); break;
                    case "endDate_desc": query = query.OrderByDescending(e => e.EndEventDate); break;
                    case "author": query = query.OrderBy(e => e.User.FirstName + e.User.LastName); break;
                    case "author_desc": query = query.OrderByDescending(e => e.User.FirstName + e.User.LastName); break;
                }
            }

            var events = await query
                .Skip((page - 1) * count)
                .Take(count)
                .AsNoTracking()
                .ToListAsync();

            return (events, totalCount);
        }
    }
}
