using Application.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class UserSignInValidator : AbstractValidator<UserSignInModel>
    {
        public UserSignInValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage("Musisz podać email")
                .EmailAddress()
                .WithMessage("Email jest nie poprawny");

            RuleFor(u => u.Password)
                .NotEmpty()
                .WithMessage("Musisz podać hasło");
        }
    }

    public class UserSignUpValidator : AbstractValidator<UserSignUpModel>
    {
        public UserSignUpValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage("Musisz podać email")
                .EmailAddress()
                .WithMessage("Email jest nie poprawny");

            RuleFor(u => u.FirstName)
                .NotEmpty()
                .WithMessage("Musisz podać imie");

            RuleFor(u => u.LastName)
                .NotEmpty()
                .WithMessage("Musisz podać nazwisko");

            RuleFor(u => u.Password)
                .NotEmpty()
                .WithMessage("Musisz podać hasło")
                .MinimumLength(8)
                .WithMessage("Hasło musi mieć minimum 8 znaków");

            RuleFor(u => u.ConfirmPassword)
                .Equal(u => u.Password)
                .WithMessage("Hasła nie są takie same");
        }
    }

    public class UserPasswordChangeValidator : AbstractValidator<UserPasswordChangeModel>
    {
        public UserPasswordChangeValidator()
        {
            RuleFor(u => u.OldPassword)
                .NotEmpty()
                .WithMessage("Musisz podać stare hasło");

            RuleFor(u => u.Password)
                .NotEmpty()
                .WithMessage("Musisz podać nowe hasło")
                .MinimumLength(8)
                .WithMessage("Hasło musi mieć minimum 8 znaków");

            RuleFor(u => u.ConfirmPassword)
                .Equal(u => u.Password)
                .WithMessage("Hasła nie są takie same");
        }
    }

    public class UserDataChangeValidator : AbstractValidator<UserDataChangeModel>
    {
        public UserDataChangeValidator()
        {
            RuleFor(u => u.FirstName)
                .NotEmpty()
                .WithMessage("Musisz podać imie");

            RuleFor(u => u.LastName)
                .NotEmpty()
                .WithMessage("Musisz podać nazwisko");
        }
    }
}
