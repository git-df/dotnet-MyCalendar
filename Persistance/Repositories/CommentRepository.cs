using Domain.Entity;
using Persistance.Data;
using Persistance.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly mcContext _context;

        public CommentRepository(mcContext context)
        {
            _context = context;
        }

        public async Task<Comment> AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return comment;
        }
    }
}
