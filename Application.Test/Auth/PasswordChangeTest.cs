using Application.Mapper;
using Application.Models;
using Application.Services;
using Application.Test.Mocks;
using Application.Validators;
using AutoMapper;
using Domain.Entity;
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
    public class PasswordChangeTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUserRepository> _userRepositoryMock;

        public PasswordChangeTest()
        {
            _userRepositoryMock = UserRepositoryMock.GetUserRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Auth_PasswordChange()
        {
            var authService = new AuthService(_mapper, _userRepositoryMock.Object, new UserSignInValidator(), new UserSignUpValidator(), new UserPasswordChangeValidator());

            var userPasswordChange = new UserPasswordChangeModel()
            {
                OldPassword = "Haslo123!",
                Password = "HasloZmienione",
                ConfirmPassword = "HasloZmienione"
            };

            var response = await authService.PasswordChange(
                Guid.Parse("fb8e707d-9a9d-40f6-9819-968add26204e"), userPasswordChange);

            response.Success.ShouldBe(true);
            response.Data.ShouldNotBeNull();
            response.Data.ShouldBeOfType<UserInfoModel>();
            response.Message.ShouldBeEmpty();

            var signInResponse = await authService.SignIn(new UserSignInModel() { Email = "test1@test.test", Password = "HasloZmienione" });

            signInResponse.Success.ShouldBeTrue();
        }

        [Fact]
        public async Task Auth_PasswordChange_BadGuid()
        {
            var authService = new AuthService(_mapper, _userRepositoryMock.Object, new UserSignInValidator(), new UserSignUpValidator(), new UserPasswordChangeValidator());

            var userPasswordChange = new UserPasswordChangeModel()
            {
                OldPassword = "Haslo123!",
                Password = "HasloZmienione",
                ConfirmPassword = "HasloZmienione"
            };

            var response = await authService.PasswordChange(
                Guid.Parse("fb8e707d-9a9d-40f6-9819-968add262055"), userPasswordChange);

            response.Success.ShouldBe(false);
            response.Data.ShouldBeNull();
            response.Message.ShouldBe("Nie znaleziono użytkownika o takim id");

            var signInResponse = await authService.SignIn(new UserSignInModel() { Email = "test1@test.test", Password = "HasloZmienione" });

            signInResponse.Success.ShouldBe(false);
        }

        [Fact]
        public async Task Auth_PasswordChange_BadOldPassword()
        {
            var authService = new AuthService(_mapper, _userRepositoryMock.Object, new UserSignInValidator(), new UserSignUpValidator(), new UserPasswordChangeValidator());

            var userPasswordChange = new UserPasswordChangeModel()
            {
                OldPassword = "Haslo123!blad",
                Password = "HasloZmienione",
                ConfirmPassword = "HasloZmienione"
            };

            var response = await authService.PasswordChange(
                Guid.Parse("fb8e707d-9a9d-40f6-9819-968add26204e"), userPasswordChange);

            response.Success.ShouldBe(false);
            response.Data.ShouldBeNull();
            response.Message.ShouldBe("Błędne obecne hasło");

            var signInResponse = await authService.SignIn(new UserSignInModel() { Email = "test1@test.test", Password = "HasloZmienione" });

            signInResponse.Success.ShouldBe(false);
        }

        [Theory]
        [InlineData("", "HasloZmienione", "HasloZmienione")]
        [InlineData("Haslo123!blad", "", "HasloZmienione")]
        [InlineData("Haslo123!blad", "abc", "HasloZmienione")]
        [InlineData("Haslo123!blad", "HasloZmienione", "abc")]
        public async Task Auth_PasswordChange_NoValid(string oldPassword, string password, string confirmPasword)
        {
            var authService = new AuthService(_mapper, _userRepositoryMock.Object, new UserSignInValidator(), new UserSignUpValidator(), new UserPasswordChangeValidator());

            var response = await authService.PasswordChange(
                Guid.Parse("fb8e707d-9a9d-40f6-9819-968add26204e"), new UserPasswordChangeModel()
                {
                    OldPassword = oldPassword,
                    Password = password,
                    ConfirmPassword = confirmPasword
                });

            response.Success.ShouldBe(false);
            response.Data.ShouldBeNull();
            response.Message.ShouldBeEmpty();

            var signInResponse = await authService.SignIn(new UserSignInModel() 
            { 
                Email = "test1@test.test", 
                Password = "Haslo123!" 
            });

            signInResponse.Success.ShouldBe(true);
        }
    }
}
