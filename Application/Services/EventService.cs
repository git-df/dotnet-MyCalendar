using Application.Models;
using Application.Responses;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entity;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Persistance.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IAccesRequestRepository _accesRequestRepository;
        private readonly IValidator<EventDetailsModel> _eventDetailsValidator;
        private readonly IValidator<EventAddModel> _eventAddValidator;
        private readonly IMapper _mapper;

        public EventService(IEventRepository eventRepository, IAccesRequestRepository accesRequestRepository, IMapper mapper, IValidator<EventDetailsModel> eventDetailsvalidator, IValidator<EventAddModel> eventAddValidator)
        {
            _eventRepository = eventRepository;
            _accesRequestRepository = accesRequestRepository;
            _mapper = mapper;
            _eventDetailsValidator = eventDetailsvalidator;
            _eventAddValidator = eventAddValidator;
        }

        public async Task<ServiceResponse<int>> AddEvent(Guid userId, EventAddModel eventAdd)
        {
            if (!_eventAddValidator.Validate(eventAdd).IsValid)
            {
                return new ServiceResponse<int>()
                {
                    Success = false
                };
            }

            var newEvent = _mapper.Map<Event>(eventAdd);

            newEvent.UserId = userId;

            var addedEvent = await _eventRepository.AddEvent(newEvent);

            if (addedEvent.Id < 1)
            {
                return new ServiceResponse<int>()
                { 
                    Success = false,
                    Message = "Nie udało się dodać wydarzenia"
                };
            }

            return new ServiceResponse<int>()
            {
                Data = addedEvent.Id
            };
        }

        public async Task<ServiceResponse<EventDetailsModel>> GetEventDetail(Guid userId, int eventId)
        {
            var eventFromBase = await _eventRepository.GetEventById(eventId);

            if (eventFromBase == null)
            {
                return new ServiceResponse<EventDetailsModel>()
                {
                    Success = false,
                    Message = "Nie znaleziono wydarzenia o takim id"
                };
            }

            var eventModel = _mapper.Map<EventDetailsModel>(eventFromBase);

            if (eventFromBase.UserId == userId)
            {
                eventModel.Editable = true;

                return new ServiceResponse<EventDetailsModel>()
                {
                    Data = eventModel
                };
            }

            var accesRequest = await _accesRequestRepository.CheckAcces(userId, eventFromBase.UserId);

            if (accesRequest == null)
            {
                return new ServiceResponse<EventDetailsModel>()
                {
                    Success = false,
                    Message = "Nie masz dostępu do tego wydarzenia"
                };
            }

            return new ServiceResponse<EventDetailsModel>()
            {
                Data = eventModel
            };
        }

        public async Task<ServiceResponse<EventDetailsModel>> UpdateEvent(Guid userId, EventDetailsModel eventDetails)
        {
            if (!_eventDetailsValidator.Validate(eventDetails).IsValid)
            {
                return new ServiceResponse<EventDetailsModel>()
                {
                    Success = false
                };
            }

            var eventFromBase = await _eventRepository.GetEventById(eventDetails.Id);

            if (eventFromBase == null)
            {
                return new ServiceResponse<EventDetailsModel>()
                {
                    Success = false,
                    Message = "Nie znaleziono wydarzenia o takim id"
                };
            }

            if (eventFromBase.UserId == userId)
            {
                eventFromBase.Title = eventDetails.Title;
                eventFromBase.Label = eventDetails.Label;
                eventFromBase.Description = eventDetails.Description;
                eventFromBase.EventDate = eventDetails.EventDate;
                eventFromBase.EndEventDate = eventDetails.EndEventDate;

                await _eventRepository.EditEvent(eventFromBase);

                return new ServiceResponse<EventDetailsModel>()
                {
                    Data = eventDetails
                };
            }


            return new ServiceResponse<EventDetailsModel>()
            {
                Success = false,
                Message = "Nie masz dostępu do tego wydarzenia"
            };
        }
    }
}
