using Application.Models;
using Application.Responses;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entity;
using FluentValidation;
using Persistance.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IValidator<UserSignInModel> _signInValidator;
        private readonly IValidator<UserSignUpModel> _signUpValidator;
        private readonly IValidator<UserPasswordChangeModel> _passwordChangeValidator;

        public AuthService(IMapper mapper, IUserRepository userRepository, IValidator<UserSignInModel> signInvalidator, IValidator<UserSignUpModel> signUpValidator, IValidator<UserPasswordChangeModel> passwordChange)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _signInValidator = signInvalidator;
            _signUpValidator = signUpValidator;
            _passwordChangeValidator = passwordChange;
        }

        public async Task<ServiceResponse<UserInfoModel>> PasswordChange(Guid userId, UserPasswordChangeModel userPassword)
        {
            if (!_passwordChangeValidator.Validate(userPassword).IsValid)
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

            if (user.Password != HashPassword($"{userPassword.OldPassword}{user.Salt}"))
            {
                return new ServiceResponse<UserInfoModel>()
                {
                    Success = false,
                    Message = "Błędne obecne hasło"
                };
            }

            user.Salt = SaltGenerator();
            user.Password = HashPassword($"{userPassword.Password}{user.Salt}");

            await _userRepository.Update(user);

            return new ServiceResponse<UserInfoModel>()
            {
                Data = _mapper.Map<UserInfoModel>(user)
            };
        }

        public async Task<ServiceResponse<UserInfoModel>> SignIn(UserSignInModel user)
        {
            if (!_signInValidator.Validate(user).IsValid)
            {
                return new ServiceResponse<UserInfoModel>()
                {
                    Success = false
                };
            }
            
            if (user.Email == null)
            {
                return new ServiceResponse<UserInfoModel>()
                {
                    Success = false,
                    Message = "Nie podano maila"
                };
            }

            var userFromBase = await _userRepository.GetByEmail(user.Email.ToLower());

            if (userFromBase == null)
            {
                return new ServiceResponse<UserInfoModel>()
                {
                    Success = false,
                    Message = "Nie znaleziono użytkownika z takim mailem"
                };
            }

            if (userFromBase.Password != HashPassword($"{user.Password}{userFromBase.Salt}"))
            {
                return new ServiceResponse<UserInfoModel>()
                {
                    Success = false,
                    Message = "Błędne hasło"
                };
            }

            return new ServiceResponse<UserInfoModel>()
            {
                Data = _mapper.Map<UserInfoModel>(userFromBase)
            };
        }

        public async Task<ServiceResponse<UserInfoModel>> SignUp(UserSignUpModel user)
        {
            if (!_signUpValidator.Validate(user).IsValid)
            {
                return new ServiceResponse<UserInfoModel>()
                {
                    Success = false
                };
            }

            var userFromBase = await _userRepository.GetByEmail(user.Email.ToLower());

            if (userFromBase != null)
            {
                return new ServiceResponse<UserInfoModel>()
                {
                    Success = false,
                    Message = "Użytkownik z takim mailem już istnieje"
                };
            }

            var newUser = _mapper.Map<User>(user);
            newUser.FirstName = newUser.FirstName.ToLower();
            newUser.LastName = newUser.LastName.ToLower();
            newUser.Email = newUser.Email.ToLower();
            newUser.Salt = SaltGenerator();
            newUser.Password = HashPassword($"{user.Password}{newUser.Salt}");

            await _userRepository.Create(newUser);

            return new ServiceResponse<UserInfoModel>()
            {
                Data = _mapper.Map<UserInfoModel>(newUser)
            };
        }

        string HashPassword(string passwordWithSalt)
        {
            SHA256 sHA256 = SHA256.Create();
            var passwordBytes = Encoding.Default.GetBytes(passwordWithSalt);
            var passwordHash = sHA256.ComputeHash(passwordBytes);
            return Convert.ToHexString(passwordHash);
        }

        string SaltGenerator()
        {
            var rng = RandomNumberGenerator.Create();
            byte[] salt = new byte[32];
            rng.GetNonZeroBytes(salt);
            return Convert.ToHexString(salt);
        }
    }
}
