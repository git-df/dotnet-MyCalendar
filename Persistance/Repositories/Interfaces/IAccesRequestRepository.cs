using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories.Interfaces
{
    public interface IAccesRequestRepository
    {
        Task<AccesRequest> CheckAcces(Guid fromUser, Guid toUser);
        Task<AccesRequest> Get(Guid fromUser, Guid toUser);
        Task<AccesRequest> GetById(int id);
        Task<List<AccesRequest>> GetAllFromUser(Guid fromUser);
        Task<List<AccesRequest>> GetAllToUser(Guid toUser);
        Task<AccesRequest> Add(Guid fromUser, Guid toUser);
        Task<AccesRequest> Accept(AccesRequest accesRequest);
        Task Delete(AccesRequest accesRequest);
    }
}
