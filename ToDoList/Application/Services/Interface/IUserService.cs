using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Application.DTOs.UserDTOs;

namespace ToDoList.Application.Services.Interface
{
    public interface IUserService
    {
        Task<bool> AddUserAsync(UserCreateDTO? user);
        Task<UserViewDTO> GetUserByIDAsync(int? id);
        Task<UserViewDTO> GetUserByUserName(string? name);
        Task<UserViewDTO> GetUserByEmail(string? email);
        Task<bool> UpdateUserAsync(UserUpdateDTO? user);
        Task<bool> DeleteUserAsync(int? id);
    }
}