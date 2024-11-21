using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Models;
using ToDoList.Infrastruture.Data;
using ToDoList.Infrastruture.Repository.Interfaces;

namespace ToDoList.Infrastruture.Repository.Implementation
{
    public class UserRepository:IUserRepository
    {
        private readonly AppContextDB _appContextDB;
        private readonly ILogger<IUserRepository> _logger;

        public UserRepository(AppContextDB appContextDB, ILogger<IUserRepository> logger){
            _appContextDB = appContextDB;
            _logger = logger;
        }

        public async Task<bool> AddUserAsync(UserModel? user){
            try{
                _appContextDB.UserModelSet.Add(user);
                await _appContextDB.SaveChangesAsync();
                _logger.LogInformation("Success in add user in repository");
                return true;

            }catch(Exception ex){
                _logger.LogError("An error occurred while add user in repository => ex:" + ex.Message);
                return false;

            }
        }
        public async Task<UserModel> GetUserByIdAsync(int? id){
            try{
                var user = await _appContextDB.UserModelSet.FindAsync(id);
                if(user == null) throw new Exception($"User Not Found by id {id}");
                _logger.LogInformation($"Success in get user by id {id} in repository");
                return user;

            }catch(Exception ex){
                _logger.LogError($"An error occurred while get user by id {id} => ex:" + ex.Message);
                return null;
            }
        }
        public async Task<UserModel> GetUserByNameAsync(string? name){
            try{
                var user = await _appContextDB.UserModelSet.FirstOrDefaultAsync(x => x.Name == name);
                if(user == null) throw new Exception($"User Not Found by name {name}");
                _logger.LogInformation($"Success in get user by name {name} in repository");
                return user;

            }catch(Exception ex){
                _logger.LogError($"An error occurred while get user by name {name} => ex:" + ex.Message);
                return null;
            }
        }
        public async Task<UserModel> GetUserByEmailAsync(string? email){
            try{
                var user = await _appContextDB.UserModelSet.FirstOrDefaultAsync(x => x.Email == email);
                if(user == null) throw new Exception($"User Not Found by email {email}");
                _logger.LogInformation($"Success in get user by email {email} in repository");
                return user;

            }catch(Exception ex){
                _logger.LogError($"An error occurred while get user by email {email} => ex:" + ex.Message);
                return null;
            }
        }
        public async Task<bool> UpdateUserAsync(UserModel? user){
            try{
                var exist_user = await _appContextDB.UserModelSet.AnyAsync(x => x.Id == user.Id);
                if(exist_user == false) throw new Exception($"User Not Found by id {user.Id} for update");
                _appContextDB.UserModelSet.Update(user);
                await _appContextDB.SaveChangesAsync();
                _logger.LogInformation($"Success in update user by id {user.Id} in repository");
                return true;

            }catch(Exception ex){
                _logger.LogError($"An error occurred while update user by id {user.Id} => ex:" + ex.Message);
                return false;
            }
        }
        public async Task<bool> DeleteUserAsync(int? id){
            try{
                var user = await _appContextDB.UserModelSet.FindAsync(id);
                if(user == null) throw new Exception($"User Not Found by id {id}");
                _appContextDB.UserModelSet.Remove(user);
                await _appContextDB.SaveChangesAsync();
                _logger.LogInformation($"Success in remove user by id {id} in repository");
                return true;

            }catch(Exception ex){
                _logger.LogError($"An error occurred while remove user by id {id} => ex:" + ex.Message);
                return false;
            }
        }
    }
}