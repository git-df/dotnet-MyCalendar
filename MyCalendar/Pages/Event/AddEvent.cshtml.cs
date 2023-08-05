using Application.Models;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace MyCalendar.Pages.Event
{
    [Authorize(Policy = "User")]
    public class AddEventModel : PageModel
    {
        private readonly IEventService _eventService;

        public AddEventModel(IEventService eventService)
        {
            _eventService = eventService;
        }

        [BindProperty]
        public EventAddModel EventAddModel { get; set; } = new EventAddModel();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var response = await _eventService.AddEvent(Guid.Parse(User.FindFirstValue("Id")), EventAddModel);

            if (!response.Success)
            {
                if (!response.Message.IsNullOrEmpty())
                {
                    ViewData["Message"] = response.Message;
                }
                return Page();
            }

            return RedirectToPage("/Event/Details", new { eventId = response.Data });
        }
    }
}
