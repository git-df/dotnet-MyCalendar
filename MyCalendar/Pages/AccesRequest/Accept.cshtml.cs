using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace MyCalendar.Pages.AccesRequest
{
    public class AcceptModel : PageModel
    {
        private readonly IAccesRequestService _accesRequestService;

        public AcceptModel(IAccesRequestService accesRequestService)
        {
            _accesRequestService = accesRequestService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            await _accesRequestService.Accept(
                Guid.Parse(User.FindFirstValue("Id")), id);

            return RedirectToPage("/AccesRequest/ToUser");
        }
    }
}
