using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByGuid(Guid guid);
        Task<User> GetByEmail(string email);
        Task<User> Create(User user);
        Task<User> Update(User user);
    }
}
