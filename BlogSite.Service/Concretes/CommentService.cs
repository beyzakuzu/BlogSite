using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.Models.Dtos.Comments.Request;
using BlogSite.Models.Dtos.Comments.Response;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstratcts;
using Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Service.Concretes
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public ReturnModel<CommentResponseDto> Add(CreateCommentRequest create)
        {
            Comment createdComment = _mapper.Map<Comment>(create);
            createdComment.Id = Guid.NewGuid();

            _commentRepository.Add(createdComment);

            CommentResponseDto response = _mapper.Map<CommentResponseDto>(createdComment);

            return new ReturnModel<CommentResponseDto>
            {
                Data = response,
                Message = "Yorum Eklendi.",
                StatusCode = 200,
                Success = true
            };
        }

        public ReturnModel<List<CommentResponseDto>> GetAll()
        {
            List<Comment> comments = _commentRepository.GetAll();
            List<CommentResponseDto> responses = _mapper.Map<List<CommentResponseDto>>(comments);

            return new ReturnModel<List<CommentResponseDto>>
            {
                Data = responses,
                Message = string.Empty,
                StatusCode = 200,
                Success = true
            };
        }

        public ReturnModel<CommentResponseDto?> GetById(Guid id)
        {
            var comment = _commentRepository.GetById(id);
            var response = _mapper.Map<CommentResponseDto>(comment);

            return new ReturnModel<CommentResponseDto?>
            {
                Data = response,
                Message = string.Empty,
                StatusCode = 200,
                Success = true
            };
        }

        public ReturnModel<CommentResponseDto> Remove(Guid id)
        {
            Comment comment = _commentRepository.GetById(id);
            Comment deletedComment = _commentRepository.Remove(comment);

            CommentResponseDto response = _mapper.Map<CommentResponseDto>(deletedComment);

            return new ReturnModel<CommentResponseDto>
            {
                Data = response,
                Message = "Yorum Silindi.",
                StatusCode = 200,
                Success = true
            };
        }

        public ReturnModel<CommentResponseDto> Update(UpdateCommentRequest updateComment)
        {
            Comment comment = _commentRepository.GetById(updateComment.Id);

            comment.Text = updateComment.Text;

            Comment updatedComment = _commentRepository.Update(comment);

            CommentResponseDto dto = _mapper.Map<CommentResponseDto>(updatedComment);

            return new ReturnModel<CommentResponseDto>
            {
                Data = dto,
                Message = "Yorum Güncellendi",
                StatusCode = 200,
                Success = true
            };
        }
        public ReturnModel<List<CommentResponseDto>> GetCommentsByPost(Guid postId)
        {
            List<Comment> comments = _commentRepository.GetCommentsByPost(postId);
            List<CommentResponseDto> response = _mapper.Map<List<CommentResponseDto>>(comments);

            return new ReturnModel<List<CommentResponseDto>>
            {
                Data = response,
                Message = string.Empty,
                StatusCode = 200,
                Success = true
            };
        }
    }
}


