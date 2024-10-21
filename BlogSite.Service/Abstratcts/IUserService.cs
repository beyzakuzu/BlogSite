using BlogSite.Models.Dtos.Users.Request;
using BlogSite.Models.Dtos.Users.Response;
using Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Service.Abstratcts
{
    public interface IUserService
    {
        ReturnModel<List<UserResponseDto>> GetAll();
        ReturnModel<UserResponseDto?> GetById(long id);
        ReturnModel<UserResponseDto> Add(CreateUserRequest create);
        ReturnModel<UserResponseDto> Update(UpdateUserRequest updateUser);
        ReturnModel<UserResponseDto> Remove(long id);
    }

}
