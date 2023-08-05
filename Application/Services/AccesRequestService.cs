using Application.Models;
using Application.Responses;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entity;
using FluentValidation;
using Persistance.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AccesRequestService : IAccesRequestService
    {
        private readonly IAccesRequestRepository _accesRequestRepository;
        private readonly IUserRepository _userRepository;
        private readonly IValidator<AccesRequestSendModel> _sendValidator;
        private readonly IMapper _mapper;

        public AccesRequestService(IAccesRequestRepository accesRequestRepository, IMapper mapper, IValidator<AccesRequestSendModel> sendValidator, IUserRepository userRepository)
        {
            _accesRequestRepository = accesRequestRepository;
            _mapper = mapper;
            _sendValidator = sendValidator;
            _userRepository = userRepository;
        }

        public async Task<ServiceResponse<string>> Accept(Guid userId, int id)
        {
            var request = await _accesRequestRepository.GetById(id);

            if (request == null)
            {
                return new ServiceResponse<string>()
                {
                    Success = false
                };
            }

            if (request.ToUserId != userId)
            {
                return new ServiceResponse<string>()
                {
                    Success = false
                };
            }

            await _accesRequestRepository.Accept(request);
            return new ServiceResponse<string>();
        }

        public async Task<ServiceResponse<string>> Delete(Guid userId, int id)
        {
            var request = await _accesRequestRepository.GetById(id);

            if (request == null)
            {
                return new ServiceResponse<string>()
                {
                    Success = false
                };
            }

            if (request.FromUserId != userId && request.ToUserId != userId)
            {
                return new ServiceResponse<string>()
                {
                    Success = false
                };
            }

            await _accesRequestRepository.Delete(request);

            return new ServiceResponse<string>();
        }

        public async Task<ServiceResponse<AccesRequestsListModel>> GetFromUserRequests(Guid userId)
        {
            var requests = await _accesRequestRepository.GetAllFromUser(userId);
            var accepted = new List<AccesRequestOnListModel>();
            var noAccepted = new List<AccesRequestOnListModel>();

            if (requests == null)
            {
                return new ServiceResponse<AccesRequestsListModel>()
                {
                    Success = false,
                    Message = "Brak rekorów"
                };
            }

            foreach (var request in requests)
            {
                if (request.IsAccepted)
                {
                    accepted.Add(new AccesRequestOnListModel()
                    {
                        Id = request.Id,
                        UserEmail = request.ToUser.Email
                    });
                }
                else
                {
                    noAccepted.Add(new AccesRequestOnListModel()
                    {
                        Id = request.Id,
                        UserEmail = request.ToUser.Email
                    });
                }
            }

            return new ServiceResponse<AccesRequestsListModel>()
            {
                Data = new AccesRequestsListModel()
                {
                    Accepted = accepted,
                    NoAccepted = noAccepted
                }
            };
        }

        public async Task<ServiceResponse<AccesRequestsListModel>> GetToUserRequests(Guid userId)
        {
            var requests = await _accesRequestRepository.GetAllToUser(userId);

            var accepted = new List<AccesRequestOnListModel>();
            var noAccepted = new List<AccesRequestOnListModel>();

            if (requests == null)
            {
                return new ServiceResponse<AccesRequestsListModel>()
                {
                    Success = false,
                    Message = "Brak rekorów"
                };
            }

            foreach (var request in requests)
            {
                if (request.IsAccepted)
                {
                    accepted.Add(new AccesRequestOnListModel()
                    {
                        Id = request.Id,
                        UserEmail = request.FromUser.Email
                    });
                }
                else
                {
                    noAccepted.Add(new AccesRequestOnListModel()
                    {
                        Id = request.Id,
                        UserEmail = request.FromUser.Email
                    });
                }
            }

            return new ServiceResponse<AccesRequestsListModel>()
            {
                Data = new AccesRequestsListModel()
                {
                    Accepted = accepted,
                    NoAccepted = noAccepted
                }
            };
        }

        public async Task<ServiceResponse<int>> SendRequest(Guid userId, AccesRequestSendModel accesRequest)
        {
            if (!_sendValidator.Validate(accesRequest).IsValid)
            {
                return new ServiceResponse<int>()
                {
                    Success = false
                };
            }

            var toUser = await _userRepository.GetByEmail(accesRequest.ToUserEmail.ToLower());

            if (toUser == null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Data = 0,
                    Message = "Nie ma użytkownika z takim mailem"
                };
            }

            var request = await _accesRequestRepository.Get(userId, toUser.Id);

            if (request != null)
            {
                if (request.IsAccepted)
                {
                    return new ServiceResponse<int>()
                    {
                        Success = false,
                        Data = request.Id,
                        Message = "Masz już dostęp do tego kalendarza"
                    };
                }

                return new ServiceResponse<int>()
                {
                    Success = false,
                    Data = request.Id,
                    Message = "Prośba czeka na akceptacje"
                };
            }

            if (toUser.Id == userId)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Data = 0,
                    Message = "Nie możesz wysłąć sobie zaproszenia"
                };
            }

            var newRequest = await _accesRequestRepository.Add(userId, toUser.Id);

            if (newRequest == null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Data = 0,
                    Message = "Nie udało się wysłać"
                };
            }

            return new ServiceResponse<int>()
            {
                Data = newRequest.Id
            };
        }
    }
}
