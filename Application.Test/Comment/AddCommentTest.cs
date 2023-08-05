using Application.Mapper;
using Application.Services;
using Application.Test.Mocks;
using Application.Validators;
using AutoMapper;
using FluentAssertions;
using Moq;
using Persistance.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Test.Comment
{
    public class AddCommentTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICommentRepository> _commentRepositoryMock;

        public AddCommentTest()
        {
            _commentRepositoryMock = CommentRepositoryMock.GetCommentRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Theory]
        [InlineData("i")]
        [InlineData("iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii")]
        public async Task Comment_AddComment(string message)
        {
            var commentService = new CommentService(_commentRepositoryMock.Object, new CommentAddValidator(), _mapper);

            var response = await commentService.AddComment(Guid.Parse("fb8e707d-9a9d-40f6-9819-968add26204e"), 1, new Models.CommentAddModel()
            {
                Message = message
            });

            response.Success.Should().BeTrue();
            response.Message.Should().BeEmpty();
            response.Data.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData("")]
        [InlineData("iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii")]
        public async Task Comment_AddComment_NoValid(string message)
        {
            var commentService = new CommentService(_commentRepositoryMock.Object, new CommentAddValidator(), _mapper);

            var response = await commentService.AddComment(Guid.Parse("fb8e707d-9a9d-40f6-9819-968add262011"), 1, new Models.CommentAddModel()
            {
                Message = message
            });

            response.Success.Should().BeFalse();
            response.Message.Should().BeEmpty();
            response.Data.Should().Be(0);
        }
    }
}
