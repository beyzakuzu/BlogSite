using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Models.Dtos.Users.Request
{
    public sealed record UpdateUserRequest(long Id, string FirstName, string LastName, string Email, string Username);

}
