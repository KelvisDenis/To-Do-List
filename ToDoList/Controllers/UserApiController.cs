using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.DTOs.UserDTOs;
using ToDoList.Application.Services.Interface;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserApiController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserApiController> _logger;

        public UserApiController(IUserService userService, ILogger<UserApiController> logger){
            _userService = userService;
            _logger = logger;

        }


        [HttpGet("User/GET/id={id}")]
        public async Task<ActionResult> GetByID(int? id){
            if(id == null) return BadRequest("Parm is null");

            try{
                var response = await _userService.GetUserByIDAsync(id);
                if(response == null) throw new Exception($"An error occurred while get user by id {id}");
                _logger.LogInformation($"Success in get user by id {id}");
                return Ok(response);

            }catch(Exception ex){
                _logger.LogError(ex.Message);
                return BadRequest($"Not Found user by id {id}");
            }
        }
        [HttpGet("User/GET/name={name}")]
        public async Task<ActionResult> GetByName(string? name){
            if(name == null) return BadRequest("Parm is null");

            try{
                var response = await _userService.GetUserByUserName(name);
                if(response == null) throw new Exception($"An error occurred while get user by name {name}");
                _logger.LogInformation($"Success in get user by name {name}");
                return Ok(response);

            }catch(Exception ex){
                _logger.LogError(ex.Message);
                return BadRequest($"Not Found user by name {name}");
            }
        }
        [HttpGet("User/GET/email={email}")]
        public async Task<ActionResult> GetByEmail(string? email){
            if(email == null) return BadRequest("Parm is null");

            try{
                var response = await _userService.GetUserByEmail(email);
                if(response == null) throw new Exception($"An error occurred while get user by email {email}");
                _logger.LogInformation($"Success in get user by email {email}");
                return Ok(response);

            }catch(Exception ex){
                _logger.LogError(ex.Message);
                return BadRequest($"Not Found user by email {email}");
            }
        }

        [HttpPost("User/Add")]
        public async Task<ActionResult> Create([FromBody] UserCreateDTO? model){
            if(model == null) return BadRequest("Parm is null");

            try{
                var response = await _userService.AddUserAsync(model);
                if(response == false) throw new Exception($"An error occurred while add user by id {model.Id}");
                var user = await _userService.GetUserByEmail(model.Email);
                _logger.LogInformation($"Success in add user by id {model.Id}");
                return Ok(user);

            }catch(Exception ex){
                _logger.LogError(ex.Message);
                return BadRequest($"Not created user by id {model.Id}");
            }
        }
        [HttpPut("User/Update")]
        public async Task<ActionResult> Update([FromBody] UserUpdateDTO? model){
            if(model == null) return BadRequest("Parm is null");
            try{
                var response = await _userService.UpdateUserAsync(model);
                if(response == false) throw new Exception($"An error occurred while update user by id {model.Id}");
                var user = await _userService.GetUserByIDAsync(model.Id);
                _logger.LogInformation($"Success in update user by id {model.Id}");
                return Ok(user);

            }catch(Exception ex){
                _logger.LogError(ex.Message);
                return BadRequest($"Not Update user by id {model.Id}");
            }
        }
        [HttpDelete("User/Delete/id={id}")]
        public async Task<ActionResult> Delete(int? id){
            if(id == null) return BadRequest("Parm is null");

            try{
                var response = await _userService.DeleteUserAsync(id);
                if(response == false) throw new Exception($"An error occurred while remove user by id {id}");
                _logger.LogInformation($"Success in remove user by id {id}");
                return Ok("User deleted with success" + response);

            }catch(Exception ex){
                _logger.LogError(ex.Message);
                return BadRequest($"Not deleted user by id {id}");
            }
        }
        
    }
}