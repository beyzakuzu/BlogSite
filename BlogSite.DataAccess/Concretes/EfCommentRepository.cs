using BlogSite.DataAccess.Abstracts;
using BlogSite.DataAccess.Contexts;
using BlogSite.Models.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.DataAccess.Concretes
{
   public class EfCommentRepository : EfRepositoryBase<BaseDbContext, Comment, Guid>, ICommentRepository
{
    public EfCommentRepository(BaseDbContext context) : base(context)
    {
    }
    public List<Comment> GetCommentsByPost(Guid postId)
      {
            return Context.Comments.Where(c => c.PostId == postId).ToList();
      }
    }

}
