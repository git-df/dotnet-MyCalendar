using Application.Models;
using Application.Services;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace MyCalendar.Pages.Comment
{
    public class AddCommentModel : PageModel
    {
        private readonly ICommentService _commentService;

        public AddCommentModel(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [BindProperty]
        public CommentAddModel CommentAddModel { get; set; }

        public int EventId { get; set; }

        public IActionResult OnGet(int eventId)
        {
            if (eventId < 1)
            {
                return RedirectToPage("/Calendar/Index");
            }

            EventId = eventId;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int eventId)
        {
            var response = await _commentService.AddComment(Guid.Parse(User.FindFirstValue("Id")), eventId, CommentAddModel);

            if (!response.Success)
            {
                if (!response.Message.IsNullOrEmpty())
                {
                    ViewData["Message"] = response.Message;
                }
                EventId = eventId;
                return Page();
            }

            return RedirectToPage("/Event/Details", new { eventId = eventId });
        }
    }
}
