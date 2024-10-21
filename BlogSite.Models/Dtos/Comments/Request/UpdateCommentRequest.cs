using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Models.Dtos.Comments.Request
{
    public sealed record UpdateCommentRequest(Guid Id, string Text, long UserId, Guid PostId);

}
