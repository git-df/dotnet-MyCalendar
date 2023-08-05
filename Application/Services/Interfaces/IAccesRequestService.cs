using Application.Models;
using Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IAccesRequestService
    {
        Task<ServiceResponse<int>> SendRequest(Guid userId, AccesRequestSendModel accesRequest);
        Task<ServiceResponse<AccesRequestsListModel>> GetToUserRequests(Guid userId);
        Task<ServiceResponse<AccesRequestsListModel>> GetFromUserRequests(Guid userId);
        Task<ServiceResponse<string>> Delete(Guid userId, int id);
        Task<ServiceResponse<string>> Accept(Guid userId, int id);
    }
}
