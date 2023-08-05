using Application.Models;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace MyCalendar.Pages.AccesRequest
{
    [Authorize(Policy = "User")]
    public class FromUserModel : PageModel
    {
        private readonly IAccesRequestService _accesRequestService;

        public FromUserModel(IAccesRequestService accesRequestService)
        {
            _accesRequestService = accesRequestService;
        }

        public AccesRequestsListModel AccesRequestsList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var response = await _accesRequestService.GetFromUserRequests(
                Guid.Parse(User.FindFirstValue("Id")));

            if (!response.Success)
            {
                ViewData["Message"] = response.Message;
            }

            AccesRequestsList = response.Data;
            return Page();
        }
    }
}
