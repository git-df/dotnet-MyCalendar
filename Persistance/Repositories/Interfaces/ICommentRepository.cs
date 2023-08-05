using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        public Task<Comment> AddComment(Comment comment);
    }
}
