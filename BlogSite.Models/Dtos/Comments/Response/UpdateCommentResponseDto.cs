using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Models.Dtos.Comments.Response
{
    public sealed record UpdateCommentResponseDto
    {
        public Guid Id { get; init; }
        public string Text { get; init; }
        public string UserName { get; init; }
        public string PostTitle { get; init; }
        public DateTime UpdatedDate { get; init; }
    }

}
