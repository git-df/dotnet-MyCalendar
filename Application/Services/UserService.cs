using Application.Models;
using Application.Responses;
using Application.Services.Interfaces;
using AutoMapper;
using FluentValidation;
using Persistance.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IValidator<UserDataChangeModel> _dataChangeValidator;

        public UserService(IMapper mapper, IUserRepository userRepository, IValidator<UserDataChangeModel> dataChangeValidator)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _dataChangeValidator = dataChangeValidator;
        }

        public async Task<ServiceResponse<UserInfoModel>> GetUserInfo(Guid userId)
        {
            var user = await _userRepository.GetByGuid(userId);

            if (user == null)
            {
                return new ServiceResponse<UserInfoModel>()
                {
                    Success = false,
                    Message = "Nie znaleziono użytkownika o takim id"
                };
            }

            return new ServiceResponse<UserInfoModel>()
            {
                Data = _mapper.Map<UserInfoModel>(user)
            };
        }

        public async Task<ServiceResponse<UserInfoModel>> UserDataChange(Guid userId, UserDataChangeModel dataChangeModel)
        {
            if (!_dataChangeValidator.Validate(dataChangeModel).IsValid)
            {
                return new ServiceResponse<UserInfoModel>()
                {
                    Success = false
                };
            }

            var user = await _userRepository.GetByGuid(userId);

            if (user == null)
            {
                return new ServiceResponse<UserInfoModel>()
                {
                    Success = false,
                    Message = "Nie znaleziono użytkownika o takim id"
                };
            }

            user.FirstName = dataChangeModel.FirstName.ToLower();
            user.LastName = dataChangeModel.LastName.ToLower();

            await _userRepository.Update(user);

            return new ServiceResponse<UserInfoModel>()
            {
                Data = _mapper.Map<UserInfoModel>(user)
            };
        }
    }
}
