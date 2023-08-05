using Application.Mapper;
using Application.Models;
using Application.Services;
using Application.Test.Mocks;
using Application.Validators;
using AutoMapper;
using Moq;
using Persistance.Repositories.Interfaces;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Test.Auth
{
    public class SignUpTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUserRepository> _userRepositoryMock;

        public SignUpTest()
        {
            _userRepositoryMock = UserRepositoryMock.GetUserRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Auth_SignUp()
        {
            var authService = new AuthService(_mapper, _userRepositoryMock.Object, new UserSignInValidator(), new UserSignUpValidator(), new UserPasswordChangeValidator());

            var userSignUp = new UserSignUpModel()
            {
                Email = "test4@test.test",
                FirstName = "test4first",
                LastName = "test4last",
                Password = "Haslo123!",
                ConfirmPassword = "Haslo123!"
            };

            var response = await authService.SignUp(userSignUp);

            response.Success.ShouldBe(true);
            response.Data.ShouldNotBeNull();
            response.Data.ShouldBeOfType<UserInfoModel>();
            response.Message.ShouldBeEmpty();

            var addedUser = await _userRepositoryMock.Object.GetByEmail(userSignUp.Email);
            
            addedUser.ShouldNotBeNull();
            addedUser.Email.ShouldBe(userSignUp.Email.ToLower());
            addedUser.FirstName.ShouldBe(userSignUp.FirstName.ToLower());
            addedUser.LastName.ShouldBe(userSignUp.LastName.ToLower());
        }

        [Fact]
        public async Task Auth_SignUp_UserExist()
        {
            var authService = new AuthService(_mapper, _userRepositoryMock.Object, new UserSignInValidator(), new UserSignUpValidator(), new UserPasswordChangeValidator());

            var userSignUp = new UserSignUpModel()
            {
                Email = "test3@test.test",
                FirstName = "Ntest3first",
                LastName = "Ntest3last",
                Password = "Haslo123!",
                ConfirmPassword = "Haslo123!"
            };

            var response = await authService.SignUp(userSignUp);

            response.Success.ShouldBe(false);
            response.Data.ShouldBeNull();
            response.Message.ShouldBe("Użytkownik z takim mailem już istnieje");

            var addedUser = await _userRepositoryMock.Object.GetByEmail(userSignUp.Email);

            addedUser.ShouldNotBeNull();
            addedUser.Email.ShouldBe(userSignUp.Email.ToLower());
            addedUser.FirstName.ShouldNotBe(userSignUp.FirstName.ToLower());
            addedUser.LastName.ShouldNotBe(userSignUp.LastName.ToLower());
        }

        [Theory]
        [InlineData("abc", "Test", "Test", "Haslo123!", "Haslo123!")]
        [InlineData("", "Test", "Test", "Haslo123!", "Haslo123!")]
        [InlineData("test@test.test", "", "Test", "Haslo123!", "Haslo123!")]
        [InlineData("test@test.test", "Test", "", "Haslo123!", "Haslo123!")]
        [InlineData("test@test.test", "Test", "Test", "Haslo", "Haslo")]
        [InlineData("test@test.test", "Test", "Test", "", "")]
        [InlineData("test@test.test", "Test", "Test", "Haslo123!", "123")]
        public async Task Auth_SignUp_NoValid(string email, string firstName, string lastName, string password, string confirmPassword)
        {
            var authService = new AuthService(_mapper, _userRepositoryMock.Object, new UserSignInValidator(), new UserSignUpValidator(), new UserPasswordChangeValidator());

            var response = await authService.SignUp(new UserSignUpModel()
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Password = password,
                ConfirmPassword = confirmPassword
            });

            response.Success.ShouldBe(false);
            response.Data.ShouldBeNull();
            response.Message.ShouldBeEmpty();
        }
    }
}
