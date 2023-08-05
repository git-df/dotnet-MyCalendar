using Application.Models;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace MyCalendar.Pages.Auth
{
    [Authorize(Policy = "User")]
    public class PasswordChangeModel : PageModel
    {
        private readonly IAuthService _authService;

        public PasswordChangeModel(IAuthService authService)
        {
            _authService = authService;
        }

        [BindProperty]
        public UserPasswordChangeModel UserPasswordChangeModel { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var response = await _authService.PasswordChange(
                Guid.Parse(User.FindFirstValue("Id")), UserPasswordChangeModel);

            if (!response.Success)
            {
                ViewData["Message"] = response.Message;
                return Page();
            }

            return RedirectToPage("/Index");
        }
    }
}
