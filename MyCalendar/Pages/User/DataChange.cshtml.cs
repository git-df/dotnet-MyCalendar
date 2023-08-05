using Application.Models;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace MyCalendar.Pages.User
{
    [Authorize(Policy = "User")]
    public class DataChangeModel : PageModel
    {
        private readonly IUserService _userService;

        public DataChangeModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public UserDataChangeModel UserDataChangeModel { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (UserDataChangeModel == null)
            {
                UserDataChangeModel = new UserDataChangeModel();
            }

            var response = await _userService.GetUserInfo(
                Guid.Parse(User.FindFirstValue("Id")));

            if (!response.Success)
            {
                ViewData["Message"] = response.Message;
                return Page();
            }

            UserDataChangeModel.FirstName = response.Data.FirstName;
            UserDataChangeModel.LastName = response.Data.LastName;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var response = await _userService.UserDataChange(
                Guid.Parse(User.FindFirstValue("Id")), UserDataChangeModel);

            if (!response.Success)
            {
                ViewData["Message"] = response.Message;
                return Page();
            }

            return RedirectToPage("/Index");
        }
    }
}
