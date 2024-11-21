using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastruture.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> AddUserAsync(UserModel? user);
        Task<UserModel> GetUserByIdAsync(int? id);
        Task<UserModel> GetUserByNameAsync(string? name);
        Task<UserModel> GetUserByEmailAsync(string? email);
        Task<bool> UpdateUserAsync(UserModel? user);
        Task<bool> DeleteUserAsync(int? id);
    }
}