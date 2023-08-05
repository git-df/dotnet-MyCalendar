using Application.Models;
using Domain.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class EventDetailsValidator : AbstractValidator<EventDetailsModel>
    {
        public EventDetailsValidator()
        {
            RuleFor(e => e.Title)
                .NotEmpty()
                .WithMessage("Musisz podać tytuł");

            RuleFor(e => e.Description)
                .NotEmpty()
                .WithMessage("Musisz podać opis")
                .MaximumLength(200)
                .WithMessage("Maksymalnie 200 znaków");

            RuleFor(e => e.Label)
                .NotEmpty()
                .WithMessage("Musisz podać etykiete");

            RuleFor(e => e.EventDate)
                .GreaterThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("Data nie może być przeszła");

            RuleFor(e => e.EndEventDate)
                .GreaterThanOrEqualTo(e => e.EventDate)
                .WithMessage("Data nie może mniejsza niż data wydarzenia");
        }
    }

    public class EventAddValidator : AbstractValidator<EventAddModel>
    {
        public EventAddValidator()
        {
            RuleFor(e => e.Title)
                .NotEmpty()
                .WithMessage("Musisz podać tytuł");

            RuleFor(e => e.Description)
                .NotEmpty()
                .WithMessage("Musisz podać opis")
                .MaximumLength(200)
                .WithMessage("Maksymalnie 200 znaków");

            RuleFor(e => e.Label)
                .NotEmpty()
                .WithMessage("Musisz podać etykiete");

            RuleFor(e => e.EventDate)
                .GreaterThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("Data nie może być przeszła");

            RuleFor(e => e.EndEventDate)
                .GreaterThanOrEqualTo(e => e.EventDate)
                .WithMessage("Data nie może mniejsza niż data wydarzenia");
        }
    }
}
