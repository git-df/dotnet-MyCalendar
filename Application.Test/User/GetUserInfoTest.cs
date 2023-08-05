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

namespace Application.Test.User
{
    public class GetUserInfoTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUserRepository> _userRepositoryMock;

        public GetUserInfoTest()
        {
            _userRepositoryMock = UserRepositoryMock.GetUserRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task User_GetUserInfo()
        {
            var userService = new UserService(_mapper, _userRepositoryMock.Object, new UserDataChangeValidator());

            var response = await userService.GetUserInfo(Guid.Parse("fb8e707d-9a9d-40f6-9819-968add26204e"));

            response.Success.ShouldBe(true);
            response.Data.ShouldNotBeNull();
            response.Data.ShouldBeOfType<UserInfoModel>();
            response.Data.Id.ShouldBe(Guid.Parse("fb8e707d-9a9d-40f6-9819-968add26204e"));
            response.Data.FirstName.ShouldBe("test1first");
            response.Data.LastName.ShouldBe("test1last");
            response.Data.Email.ShouldBe("test1@test.test");
            response.Message.ShouldBeEmpty();
        }

        [Fact]
        public async Task User_GetUserInfo_BadGuid()
        {
            var userService = new UserService(_mapper, _userRepositoryMock.Object, new UserDataChangeValidator());

            var response = await userService.GetUserInfo(Guid.Parse("fb8e707d-9a9d-40f6-9819-968add262055"));

            response.Success.ShouldBe(false);
            response.Data.ShouldBeNull();
            response.Message.ShouldBe("Nie znaleziono użytkownika o takim id");
        }
    }
}
