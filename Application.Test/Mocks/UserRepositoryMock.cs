using Application.Test.Mocks.Data;
using Moq;
using Persistance.Repositories.Interfaces;

namespace Application.Test.Mocks
{
    public class UserRepositoryMock
    {
        public static Mock<IUserRepository> GetUserRepository() 
        {
            var _context = new ContextMock();

            var mockUserRepository = new Mock<IUserRepository>();

            mockUserRepository.Setup(repo => repo.GetByGuid(It.IsAny<Guid>())).ReturnsAsync(
                (Guid id) =>
                {
                    return _context.Users.FirstOrDefault(u => u.Id == id);
                });

            mockUserRepository.Setup(repo => repo.GetByEmail(It.IsAny<string>())).ReturnsAsync(
                (string email) =>
                {
                    return _context.Users.FirstOrDefault(u => u.Email == email);
                });

            mockUserRepository.Setup(repo => repo.Create(It.IsAny<Domain.Entity.User> ())).ReturnsAsync(
                (Domain.Entity.User user) =>
                {
                    user.Id = Guid.NewGuid();
                    _context.Users.Add(user);
                    return user;
                });

            mockUserRepository.Setup(repo => repo.Update(It.IsAny<Domain.Entity.User>())).ReturnsAsync(
                (Domain.Entity.User user) =>
                {
                    _context.Users.Remove(user);
                    _context.Users.Add(user);
                    return user;
                });

            return mockUserRepository;
        }
    }
}
