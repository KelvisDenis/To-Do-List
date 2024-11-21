using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.DTOs.ActionListDTOs;
using ToDoList.Application.Services.Interface;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActionApiController : ControllerBase
    {
        private readonly IActionListServices _actionListServices;
        private readonly IUserService _userService;
        private readonly ILogger<ActionApiController> _logger;

        public ActionApiController(IActionListServices actionListServices, ILogger<ActionApiController> logger, IUserService userService){
            _actionListServices = actionListServices;
            _logger = logger;
            _userService = userService;
        }

        [HttpPost("/Action/Create/")]
        public async Task<ActionResult> Create([FromBody] ActionCreateDTO? model){
            if (model == null) return BadRequest("Parm is null");
            try{
                var verify_Exist_User = await _userService.GetUserByIDAsync(model.UserID);
                if (verify_Exist_User == null) throw new Exception($"Not Found user by id {model.Id} for created action");
                var response = await _actionListServices.AddActionAsync(model);
                if(response == false)  throw new Exception("Error occurred while add action");
                _logger.LogInformation($"Success in add action by name {model.Name}");
                return Ok("Action created with success");

            }catch(Exception ex){
                _logger.LogError(ex.Message);
                return BadRequest("An error occurred while add action in Data Base");

            }
        }
        [HttpGet("/Action/GET/ID={id}")]
        public async Task<ActionResult> GetByID(int? id){
            if (id == null) return BadRequest("Parm is null");
            try{
                var response = await _actionListServices.GetActionByID(id);
                if(response == null)  throw new Exception("Error occurred while get action by id "+ id);
                _logger.LogInformation($"Success in get action by id {id}");
                return Ok(response);

            }catch(Exception ex){
                _logger.LogError(ex.Message);
                return BadRequest($"An error occurred while get action by id {id}");
            }
        }
        [HttpGet("/Action/GET/Name={name}")]
        public async Task<ActionResult> GetByName(string? name){
            if (name == null) return BadRequest("Parm is null");
            try{
                var response = await _actionListServices.GetActionByName(name);
                if(response == null)  throw new Exception("Error occurred while get action by name "+ name);
                _logger.LogInformation($"Success in get action by name {name}");
                return Ok(response);

            }catch(Exception ex){
                _logger.LogError(ex.Message);
                return BadRequest($"An error occurred while get action by name {name}");
            }
        }

        [HttpGet("/Action/GET/ID_User={id}")]
        public async Task<ActionResult> GetByIDUser(int? id){
            if (id == null) return BadRequest("Parm is null");
            try{
                var response = await _actionListServices.GetActionByID_User(id);
                if(response == null)  throw new Exception("Error occurred while get action by id user "+ id);
                _logger.LogInformation($"Success in get action by id user {id}");
                return Ok(response);

            }catch(Exception ex){
                _logger.LogError(ex.Message);
                return BadRequest($"An error occurred while get action by id user {id}");
            }
        }
        [HttpGet("/Action/GET/All")]
        public async Task<ActionResult> GetAll(){
            try{
                var response = await _actionListServices.GetAllActions();
                if(response == null)  throw new Exception("Error occurred while get actions ");
                _logger.LogInformation($"Success in get all actions");
                return Ok(response);

            }catch(Exception ex){
                _logger.LogError(ex.Message);
                return BadRequest($"An error occurred while get all actions");
            }
        }
        [HttpPut("/Action/Update")]
        public async Task<ActionResult> Update([FromBody] ActionUpdateDTO? model){
            if (model == null) return BadRequest("Parm is null");
            try{
                var response = await _actionListServices.UpdateAction(model);
                if(response == false)  throw new Exception("Error occurred while update action by id "+ model.Id);
                var action = await _actionListServices.GetActionByID(model.Id);
                _logger.LogInformation($"Success in update action by id {model.Id}");
                return Ok(action);

            }catch(Exception ex){
                _logger.LogError(ex.Message);
                return BadRequest($"An error occurred while update action by id {model.Id}");
            }
        }
        [HttpDelete("/Action/Delete/ID={id}")]
        public async Task<ActionResult> Delete(int? id){
            if (id == null) return BadRequest("Parm is null");
            try{
                var response = await _actionListServices.RemoveActionAsync(id);
                if(response == false)  throw new Exception("Error occurred while remove action by id "+ id);
                _logger.LogInformation($"Success in remove action by id {id}");
                return Ok(response);

            }catch(Exception ex){
                _logger.LogError(ex.Message);
                return BadRequest($"An error occurred while remove action by id {id}");
            }
        }
    }
}