using Application.Models;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyCalendar.Pages.Auth
{
    public class SignInModel : PageModel
    {
        private readonly IAuthService _authService;

        public SignInModel(IAuthService authService)
        {
            _authService = authService;
        }
        
        [BindProperty]
        public UserSignInModel UserSignInModel { get; set; }

        [BindProperty(Name = "ReturnUrl", SupportsGet = true)]
        public string ReturnUrl { get; set; }

        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToPage("/Index");

            ViewData["nav"] = "disable";
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ViewData["nav"] = "disable";
            var response = await _authService.SignIn(UserSignInModel);

            if (!response.Success)
            {
                ViewData["Message"] = response.Message;
                return Page();
            }

            await SignIn(response.Data);

            if (ReturnUrl == null)
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }

        private async Task SignIn(UserInfoModel userInfoModel)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, userInfoModel.Email),
                new Claim("Id", userInfoModel.Id.ToString()),
                new Claim("FirstName", userInfoModel.FirstName),
                new Claim("LastName", userInfoModel.LastName),
                new Claim("Email", userInfoModel.Email)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

            AuthenticationProperties authenticationProperties = new AuthenticationProperties()
            {
                AllowRefresh = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authenticationProperties);
        }
    }
}
