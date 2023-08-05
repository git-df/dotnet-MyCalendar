using Application.Models;
using Application.Models.GridFilters;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using System.Drawing.Printing;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MyCalendar.Pages.Calendar
{
    [Authorize(Policy = "User")]
    public class IndexModel : PageModel
    {
        private readonly ICalendarService _calendarService;

        public IndexModel(ICalendarService calendarService)
        {
            _calendarService = calendarService;
        }

        public EventListModel EventList { get; set; }

        [BindProperty]
        public CalendarFilter Filter { get; set; }

        public async Task<IActionResult> OnGetAsync(int pageNumber = 1, int size = 10, string orderBy = "date")
        {
            EventList = EventList ?? new EventListModel();
            Filter = Filter ?? new CalendarFilter();

            var response = await _calendarService
                .GetEventsListByUser(Guid.Parse(User.FindFirstValue("Id")), Filter, pageNumber, size, orderBy);

            if (response.Success)
            {
                EventList = response.Data;
            }
            else
            {
                ViewData["Message"] = response.Message;
            }

            EventList.OrderTitleRoute = orderBy == "title" ? "title_desc" : "title";
            EventList.OrderLabeleRoute = orderBy == "label" ? "label_desc" : "label";
            EventList.OrderDateRoute = orderBy == "date" ? "date_desc" : "date";
            EventList.OrderEndDateRoute = orderBy == "endDate" ? "endDate_desc" : "endDate";
            EventList.OrderAuthorRoute = orderBy == "author" ? "author_desc" : "author";
            EventList.CurrentPage = pageNumber;
            EventList.CurrentOrder = orderBy;
            EventList.CurrentSize = size;

            return Page();
        }

        public async Task OnPostAsync(int pageNumber = 1, int size = 10, string orderBy = "date")
        {
            await OnGetAsync(pageNumber, size, orderBy);
        }
    }
}