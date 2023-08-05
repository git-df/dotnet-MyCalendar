using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace MyCalendar.Pages.AccesRequest
{
    [Authorize(Policy = "User")]
    public class DeleteModel : PageModel
    {
        private readonly IAccesRequestService _accesRequestService;

        public DeleteModel(IAccesRequestService accesRequestService)
        {
            _accesRequestService = accesRequestService;
        }

        public async Task<IActionResult> OnGetAsync(int id, string returnUrl = "/AccesRequest/FromUser")
        {
            await _accesRequestService.Delete(
                Guid.Parse(User.FindFirstValue("Id")), id);

            return RedirectToPage(returnUrl);
        }
    }
}
