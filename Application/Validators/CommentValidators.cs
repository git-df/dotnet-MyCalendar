using Application.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class CommentAddValidator : AbstractValidator<CommentAddModel>
    {
        public CommentAddValidator()
        {
            RuleFor(c => c.Message)
                .NotEmpty()
                .WithMessage("Musisz podać treść komentarza")
                .MaximumLength(250)
                .WithMessage("Maksymalna długość 250");
        }
    }
}
