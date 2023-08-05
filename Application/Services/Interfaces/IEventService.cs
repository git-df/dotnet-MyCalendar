using Application.Models;
using Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IEventService
    {
        Task<ServiceResponse<EventDetailsModel>> GetEventDetail(Guid userId, int eventId);
        Task<ServiceResponse<EventDetailsModel>> UpdateEvent(Guid userId, EventDetailsModel eventDetails);
        Task<ServiceResponse<int>> AddEvent(Guid userId, EventAddModel eventAdd);
    }
}
