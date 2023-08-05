using Application.Models;
using Application.Models.GridFilters;
using Application.Responses;
using Application.Services.Interfaces;
using AutoMapper;
using Persistance.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CalendarService : ICalendarService
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;

        public CalendarService(IMapper mapper, IEventRepository eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        public async Task<ServiceResponse<EventListModel>> GetEventsListByUser(Guid userId, CalendarFilter filter, int pageNumber, int pageSize, string orderBy)
        {
            (var events, int eventsCount) = await _eventRepository
                .GetFiltredEventsByUserId(userId, filter.FromDate, filter.ToDate.AddDays(1), filter.Filter, pageSize, pageNumber, orderBy);

            if (!(eventsCount > 0) || events == null)
            {
                return new ServiceResponse<EventListModel>()
                {
                    Success = false,
                    Message = "Brak wyników"
                };
            }

            return new ServiceResponse<EventListModel>()
            {
                Data = new EventListModel()
                {
                    Events = _mapper.Map<List<EventOnListModel>>(events),
                    EventsCount = eventsCount,
                    PagesCount = (int)Math.Ceiling(eventsCount / (double)pageSize),
                    FirstEventNumber = ((pageNumber - 1) * pageSize) + 1,
                    LastEventNumber = Math.Min((pageNumber * pageSize), eventsCount)
                }
            };
        }
    }
}
