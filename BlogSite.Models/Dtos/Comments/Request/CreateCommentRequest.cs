using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Models.Dtos.Comments.Request;

public sealed record CreateCommentRequest(string Text, long UserId, Guid PostId);
