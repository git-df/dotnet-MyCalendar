using Application.Models;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace MyCalendar.Pages.Event
{
    [Authorize(Policy = "User")]
    public class DetailsModel : PageModel
    {
        private readonly IEventService _eventService;

        public DetailsModel(IEventService eventService)
        {
            _eventService = eventService;
        }

        [BindProperty]
        public EventDetailsModel EventDetails { get; set; }

        public async Task<IActionResult> OnGetAsync(int eventId)
        {
            if (eventId <= 0)
            {
                EventDetails = new EventDetailsModel();
                ViewData["Message"] = "B³êdne id";
                return Page();
            }

            var response = await _eventService
                .GetEventDetail(Guid.Parse(User.FindFirstValue("Id")), eventId);

            if (!response.Success)
            {
                EventDetails = new EventDetailsModel();
                ViewData["Message"] = response.Message;
                return Page();
            }

            EventDetails = response.Data;
            return Page();
        }

        public async Task OnPostAsync(int eventId)
        {
            EventDetails.Id = eventId;
            var response = await _eventService.UpdateEvent(Guid.Parse(User.FindFirstValue("Id")), EventDetails);

            if (!response.Success)
            {
                ViewData["Message"] = response.Message;
            }

            await OnGetAsync(eventId);
        }
    }
}
