using Application.Test.Mocks.Data;
using Moq;
using Persistance.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Test.Mocks
{
    public class CommentRepositoryMock
    {
        public static Mock<ICommentRepository> GetCommentRepository()
        {
            var _context = new ContextMock();

            var mockCommentRepository = new Mock<ICommentRepository>();

            mockCommentRepository.Setup(repo => repo.AddComment(It.IsAny<Domain.Entity.Comment>())).ReturnsAsync(
                (Domain.Entity.Comment comment) =>
                {
                    comment.Id = _context.Comments.Max(c => c.Id) + 1;
                    _context.Comments.Add(comment);
                    return comment;
                });

            return mockCommentRepository;
        }
    }
}
