using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.Models.Dtos.Users.Request;
using BlogSite.Models.Dtos.Users.Response;
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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public ReturnModel<UserResponseDto> Add(CreateUserRequest create)
        {
            User createdUser = _mapper.Map<User>(create);
            createdUser.Id = new Random().Next(1, 10000); // Örnek bir Id atama işlemi

            _userRepository.Add(createdUser);

            UserResponseDto response = _mapper.Map<UserResponseDto>(createdUser);

            return new ReturnModel<UserResponseDto>
            {
                Data = response,
                Message = "Kullanıcı Eklendi.",
                StatusCode = 200,
                Success = true
            };
        }

        public ReturnModel<List<UserResponseDto>> GetAll()
        {
            List<User> users = _userRepository.GetAll();
            List<UserResponseDto> responses = _mapper.Map<List<UserResponseDto>>(users);

            return new ReturnModel<List<UserResponseDto>>
            {
                Data = responses,
                Message = string.Empty,
                StatusCode = 200,
                Success = true
            };
        }

        public ReturnModel<UserResponseDto?> GetById(long id)
        {
            var user = _userRepository.GetById(id);
            var response = _mapper.Map<UserResponseDto>(user);

            return new ReturnModel<UserResponseDto?>
            {
                Data = response,
                Message = string.Empty,
                StatusCode = 200,
                Success = true
            };
        }

        public ReturnModel<UserResponseDto> Remove(long id)
        {
            User user = _userRepository.GetById(id);
            User deletedUser = _userRepository.Remove(user);

            UserResponseDto response = _mapper.Map<UserResponseDto>(deletedUser);

            return new ReturnModel<UserResponseDto>
            {
                Data = response,
                Message = "Kullanıcı Silindi.",
                StatusCode = 200,
                Success = true
            };
        }

        public ReturnModel<UserResponseDto> Update(UpdateUserRequest updateUser)
        {
            User user = _userRepository.GetById(updateUser.Id);

            user.FirstName = updateUser.FirstName;
            user.LastName = updateUser.LastName;
            user.Email = updateUser.Email;
            user.Username = updateUser.Username;

            User updatedUser = _userRepository.Update(user);

            UserResponseDto dto = _mapper.Map<UserResponseDto>(updatedUser);

            return new ReturnModel<UserResponseDto>
            {
                Data = dto,
                Message = "Kullanıcı Güncellendi",
                StatusCode = 200,
                Success = true
            };
        }
    }

}
