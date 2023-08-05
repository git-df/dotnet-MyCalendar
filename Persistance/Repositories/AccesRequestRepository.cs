using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Persistance.Data;
using Persistance.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class AccesRequestRepository : IAccesRequestRepository
    {
        private readonly mcContext _context;

        public AccesRequestRepository(mcContext context)
        {
            _context = context;
        }

        public async Task<AccesRequest> Accept(AccesRequest accesRequest)
        {
            var request = await _context.AccesRequests
                .FirstOrDefaultAsync(a => a.ToUserId == accesRequest.ToUserId && a.FromUserId == accesRequest.FromUserId);
            request.IsAccepted = true;
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<AccesRequest> Add(Guid fromUser, Guid toUser)
        {
            var request = new AccesRequest()
            {
                FromUserId = fromUser,
                ToUserId = toUser
            };

            await _context.AccesRequests.AddAsync(request);
            await _context.SaveChangesAsync();

            return request;
        }

        public async Task<AccesRequest> CheckAcces(Guid fromUser, Guid toUser)
        {
            return await _context.AccesRequests
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.FromUserId == fromUser && a.ToUserId == toUser && a.IsAccepted);
        }

        public async Task Delete(AccesRequest accesRequest)
        {
            _context.Remove(accesRequest);
            await _context.SaveChangesAsync();
        }

        public async Task<AccesRequest> Get(Guid fromUser, Guid toUser)
        {
            return await _context.AccesRequests
                .Include(a => a.FromUser)
                .Include(a => a.ToUser)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.FromUserId == fromUser && a.ToUserId == toUser);
        }

        public async Task<List<AccesRequest>> GetAllFromUser(Guid fromUser)
        {
            return await _context.AccesRequests
                .Include(a => a.ToUser)
                .Where(a => a.FromUserId == fromUser)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<AccesRequest>> GetAllToUser(Guid toUser)
        {
            return await _context.AccesRequests
                .Include(a => a.FromUser)
                .Where(a => a.ToUserId == toUser)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<AccesRequest> GetById(int id)
        {
            return await _context.AccesRequests
                .FindAsync(id);
        }
    }
}
