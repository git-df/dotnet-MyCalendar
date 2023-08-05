using Application.Test.Mocks.Data;
using Domain.Entity;
using Moq;
using Persistance.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Test.Mocks
{
    public class AccesRequestRepositoryMock
    {
        public static Mock<IAccesRequestRepository> GetAccesRequestRepository()
        {
            var _context = new ContextMock();

            var mockAccesRequestRepository = new Mock<IAccesRequestRepository>();

            mockAccesRequestRepository.Setup(repo => repo.CheckAcces(It.IsAny<Guid>(), It.IsAny<Guid>())).ReturnsAsync(
                (Guid fromUser, Guid toUser) =>
                {
                    return _context.AccesRequests
                        .FirstOrDefault(a => a.FromUserId == fromUser && a.ToUserId == toUser && a.IsAccepted);
                });

            mockAccesRequestRepository.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync(
                (int id) =>
                {
                    return _context.AccesRequests
                        .Find(a => a.Id == id);
                });

            mockAccesRequestRepository.Setup(repo => repo.Get(It.IsAny<Guid>(), It.IsAny<Guid>())).ReturnsAsync(
                (Guid fromUser, Guid toUser) =>
                {
                    return _context.AccesRequests
                        .FirstOrDefault(a => a.FromUserId == fromUser && a.ToUserId == toUser);
                });

            mockAccesRequestRepository.Setup(repo => repo.GetAllFromUser(It.IsAny<Guid>())).ReturnsAsync(
                (Guid fromUser) =>
                {
                    return _context.AccesRequests
                        .Where(a => a.FromUserId == fromUser).ToList();
                });

            mockAccesRequestRepository.Setup(repo => repo.GetAllToUser(It.IsAny<Guid>())).ReturnsAsync(
                (Guid toUser) =>
                {
                    return _context.AccesRequests
                        .Where(a => a.ToUserId == toUser).ToList();
                });

            mockAccesRequestRepository.Setup(repo => repo.Add(It.IsAny<Guid>(), It.IsAny<Guid>())).ReturnsAsync(
                (Guid fromUser, Guid toUser) =>
                {
                    var request = new Domain.Entity.AccesRequest()
                    {
                        Id = _context.AccesRequests.Max(a => a.Id) + 1,
                        FromUserId = fromUser,
                        ToUserId = toUser
                    };

                    _context.AccesRequests.Add(request);
                    return request;
                });

            mockAccesRequestRepository.Setup(repo => repo.Accept(It.IsAny<Domain.Entity.AccesRequest>())).ReturnsAsync(
                (Domain.Entity.AccesRequest accesRequest) =>
                {
                    _context.AccesRequests.Remove(accesRequest);
                    accesRequest.IsAccepted = true;
                    _context.AccesRequests.Add(accesRequest);
                    return accesRequest;
                });

            mockAccesRequestRepository.Setup(repo => repo.Delete(It.IsAny<Domain.Entity.AccesRequest>())).Returns(
                (Domain.Entity.AccesRequest accesRequest) =>
                {
                    _context.AccesRequests.Remove(accesRequest);
                });

            return mockAccesRequestRepository;
        }
    }
}