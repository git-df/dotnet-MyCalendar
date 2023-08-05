using Application.Models;
using Application.Responses;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResponse<UserInfoModel>> SignIn(UserSignInModel user);
        Task<ServiceResponse<UserInfoModel>> SignUp(UserSignUpModel user);
        Task<ServiceResponse<UserInfoModel>> PasswordChange(Guid userId, UserPasswordChangeModel userPassword);
    }
}
