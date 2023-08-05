using Application.Models;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyCalendar.Pages.Auth
{
    public class SignUpModel : PageModel
    {
        private readonly IAuthService _authService;

        public SignUpModel(IAuthService authService)
        {
            _authService = authService;
        }

        [BindProperty]
        public UserSignUpModel UserSignUpModel { get; set; }

        public IActionResult OnGet()
        {
            ViewData["nav"] = "disable";
            if (User.Identity.IsAuthenticated)
                return RedirectToPage("/Index");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ViewData["nav"] = "disable";
            var response = await _authService.SignUp(UserSignUpModel);

            if (!response.Success)
            {
                ViewData["Message"] = response.Message;
                return Page();
            }

            return RedirectToPage("/Auth/SignIn");
        }
    }
}
