using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Models.Dtos.Users.Response
{
    public sealed record UpdateUserResponseDto
    {
        public long Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public string Username { get; init; }
        public DateTime UpdatedDate { get; init; }
    }
}
