using Application.Models;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace MyCalendar.Pages.AccesRequest
{
    [Authorize(Policy = "User")]
    public class SendRequestModel : PageModel
    {
        private readonly IAccesRequestService _accesRequestService;

        public SendRequestModel(IAccesRequestService accesRequestService)
        {
            _accesRequestService = accesRequestService;
        }

        [BindProperty]
        public AccesRequestSendModel AccesRequest { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var response = await _accesRequestService
                .SendRequest(Guid.Parse(User.FindFirstValue("Id")), AccesRequest);

            if (!response.Success)
            {
                ViewData["Message"] = response.Message;
                return Page();
            }

            return RedirectToPage("/AccesRequest/FromUser");
        }
    }
}
