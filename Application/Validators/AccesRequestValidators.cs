using Application.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class AccesRequestAddValidator : AbstractValidator<AccesRequestSendModel>
    {
        public AccesRequestAddValidator() 
        {
            RuleFor(a => a.ToUserEmail)
                .NotEmpty()
                .WithMessage("Musisz podać email")
                .EmailAddress()
                .WithMessage("Podaj poprawny adres email");
        }
    }
}
