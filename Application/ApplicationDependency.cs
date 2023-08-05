using Application.Models;
using Application.Services;
using Application.Services.Interfaces;
using Application.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ApplicationDependency
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICalendarService, CalendarService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IAccesRequestService, AccesRequestService>();

            services.AddFluentValidationAutoValidation();

            services.AddScoped<IValidator<UserSignInModel>, UserSignInValidator>();
            services.AddScoped<IValidator<UserSignUpModel>, UserSignUpValidator>();
            services.AddScoped<IValidator<UserDataChangeModel>, UserDataChangeValidator>();
            services.AddScoped<IValidator<UserPasswordChangeModel>, UserPasswordChangeValidator>();
            services.AddScoped<IValidator<EventDetailsModel>, EventDetailsValidator>();
            services.AddScoped<IValidator<EventAddModel>, EventAddValidator>();
            services.AddScoped<IValidator<CommentAddModel>, CommentAddValidator>();
            services.AddScoped<IValidator<AccesRequestSendModel>, AccesRequestAddValidator>();

            return services;
        }
    }
}
