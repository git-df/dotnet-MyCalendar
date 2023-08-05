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

namespace Application.Test.User
{
    public class UserDataChangeTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUserRepository> _userRepositoryMock;

        public UserDataChangeTest()
        {
            _userRepositoryMock = UserRepositoryMock.GetUserRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task User_UserDataChange()
        {
            var userService = new UserService(_mapper, _userRepositoryMock.Object, new UserDataChangeValidator());

            var userDataChange = new UserDataChangeModel()
            {
                FirstName = "Test",
                LastName = "Test",
            };

            var response = await userService.UserDataChange(
                Guid.Parse("fb8e707d-9a9d-40f6-9819-968add26204e"), userDataChange);

            response.Success.ShouldBe(true);
            response.Data.ShouldNotBeNull();
            response.Data.ShouldBeOfType<UserInfoModel>();
            response.Data.Id.ShouldBe(Guid.Parse("fb8e707d-9a9d-40f6-9819-968add26204e"));
            response.Data.FirstName.ShouldBe("test");
            response.Data.LastName.ShouldBe("test");
            response.Message.ShouldBeEmpty();
        }

        [Fact]
        public async Task User_UserDataChange_BadGuid()
        {
            var userService = new UserService(_mapper, _userRepositoryMock.Object, new UserDataChangeValidator());

            var userDataChange = new UserDataChangeModel()
            {
                FirstName = "Test",
                LastName = "Test",
            };

            var response = await userService.UserDataChange(
                Guid.Parse("fb8e707d-9a9d-40f6-9819-968add2620ee"), userDataChange);

            response.Success.ShouldBe(false);
            response.Data.ShouldBeNull();
            response.Message.ShouldBe("Nie znaleziono użytkownika o takim id");
        }

        [Theory]
        [InlineData("", "Test")]
        [InlineData("Test", "")]
        [InlineData("", "")]
        public async Task User_UserDataChange_NoValid(string firstName, string lastName)
        {
            var userService = new UserService(_mapper, _userRepositoryMock.Object, new UserDataChangeValidator());

            var response = await userService.UserDataChange(
                    Guid.Parse("fb8e707d-9a9d-40f6-9819-968add26204e"), new UserDataChangeModel()
                    {
                        FirstName = firstName,
                        LastName = lastName
                    });

            response.Success.ShouldBe(false);
            response.Data.ShouldBeNull();
            response.Message.ShouldBeEmpty();
        }
    }
}
