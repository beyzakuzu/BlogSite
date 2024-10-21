using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Models.Dtos.Categories.Response
{
    public sealed record UpdateCategoryResponseDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public DateTime UpdatedDate { get; init; }
    }

}
