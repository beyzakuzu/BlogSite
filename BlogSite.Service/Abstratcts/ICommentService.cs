using BlogSite.Models.Dtos.Comments.Request;
using BlogSite.Models.Dtos.Comments.Response;
using Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Service.Abstratcts
{
    public interface ICommentService
    {
        ReturnModel<List<CommentResponseDto>> GetAll();
        ReturnModel<CommentResponseDto?> GetById(Guid id);
        ReturnModel<CommentResponseDto> Add(CreateCommentRequest create);
        ReturnModel<CommentResponseDto> Update(UpdateCommentRequest updateComment);
        ReturnModel<CommentResponseDto> Remove(Guid id);
        ReturnModel<List<CommentResponseDto>> GetCommentsByPost(Guid postId);

    }
}
