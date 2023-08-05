using Application.Models;
using Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResponse<UserInfoModel>> UserDataChange(Guid userId, UserDataChangeModel dataChangeModel);
        Task<ServiceResponse<UserInfoModel>> GetUserInfo(Guid userId);
    }
}
