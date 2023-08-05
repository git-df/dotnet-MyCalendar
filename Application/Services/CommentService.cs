using Application.Models;
using Application.Responses;
using Application.Services.Interfaces;
using Application.Validators;
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
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IValidator<CommentAddModel> _comentAddValidator;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IValidator<CommentAddModel> comentAddValidator, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _comentAddValidator = comentAddValidator;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<int>> AddComment(Guid userId, int eventId, CommentAddModel commentAdd)
        {
            if (!_comentAddValidator.Validate(commentAdd).IsValid)
            {
                return new ServiceResponse<int>()
                {
                    Success = false
                };
            }

            var newComment = _mapper.Map<Comment>(commentAdd);
            newComment.UserId = userId;
            newComment.EventId = eventId;

            var addedComment = await _commentRepository.AddComment(newComment);

            if (addedComment.Id < 1)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = "Nie udało się dodać komentarza"
                };
            }

            return new ServiceResponse<int>()
            {
                Data = addedComment.Id
            };
        }
    }
}
