using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Application.DTOs.UserDTOs;
using ToDoList.Application.Services.Interface;
using ToDoList.Domain.Models;
using ToDoList.Infrastruture.Repository.Interfaces;

namespace ToDoList.Application.Services.Implementation
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<IUserService> _logger;

        public UserService(IUserRepository userRepository, ILogger<IUserService> logger){
            _userRepository = userRepository;
            _logger = logger;

        }

        public async Task<bool> AddUserAsync(UserCreateDTO? user){
            try{
                var mapper = new UserModel{
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.Name,
                    Password = user.Password
                };
                var response = await _userRepository.AddUserAsync(mapper);
                if(response == false) throw new Exception("An error while add user");
                _logger.LogInformation("Success in add user in service");
                return response;


            }catch(Exception ex){
                _logger.LogError("An error while add user in service " + ex.Message);
                return false;

            }
        }
        public async Task<UserViewDTO> GetUserByIDAsync(int? id){
             try{
                var response = await _userRepository.GetUserByIdAsync(id);
                if(response == null) throw new Exception($"Not Found user by id {id}");
                _logger.LogInformation($"Success in get user by id {id} in service");
                var mapper = new UserViewDTO{
                    Email = response.Email,
                    Name = response.Name
                };
                return mapper;


            }catch(Exception ex){
                _logger.LogError($"An error while get user by id {id} in service" + ex.Message);
                return null;

            }
        }
        public async Task<UserViewDTO> GetUserByUserName(string? name){
            try{
                var response = await _userRepository.GetUserByNameAsync(name);
                if(response == null) throw new Exception($"Not Found user by name {name}");
                _logger.LogInformation($"Success in get user by name {name} in service");
                var mapper = new UserViewDTO{
                    Email = response.Email,
                    Name = response.Name
                };
                return mapper;


            }catch(Exception ex){
                _logger.LogError($"An error while get user by name {name} in service" + ex.Message);
                return null;

            }
        }
        public async Task<UserViewDTO> GetUserByEmail(string? email){
             try{
                var response = await _userRepository.GetUserByEmailAsync(email);
                if(response == null) throw new Exception($"Not Found user by email {email}");
                _logger.LogInformation($"Success in get user by email {email} in service");
                var mapper = new UserViewDTO{
                    Email = response.Email,
                    Name = response.Name
                };
                return mapper;


            }catch(Exception ex){
                _logger.LogError($"An error while get user by email {email} in service" + ex.Message);
                return null;

            }
        }
        public async Task<bool> UpdateUserAsync(UserUpdateDTO? user){
            try{
                var mapper = new UserModel{
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.Name,
                    Password = user.Password
                };
                var response = await _userRepository.UpdateUserAsync(mapper);
                if(response == false) throw new Exception("An error while update user in service");
                _logger.LogInformation("Success in update user in service");
                return response;


            }catch(Exception ex){
                _logger.LogError("An error while update user in service " + ex.Message);
                return false;

            }
        }
        public async Task<bool> DeleteUserAsync(int? id){
            try{
                var response = await _userRepository.DeleteUserAsync(id);
                if(response == false) throw new Exception($"An error while remove user by id {id}");
                _logger.LogInformation($"Success in remove user by id {id} in service");
                return response;


            }catch(Exception ex){
                _logger.LogError($"An error while remove user by id {id} in service " + ex.Message);
                return false;

            }
        }
    }
}