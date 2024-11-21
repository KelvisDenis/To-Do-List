using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using ToDoList.Application.DTOs.ActionListDTOs;
using ToDoList.Application.Services.Interface;
using ToDoList.Domain.Models;
using ToDoList.Infrastruture.Repository.Interfaces;

namespace ToDoList.Application.Services.Implementation
{
    public class ActionListService:IActionListServices
    {
        private readonly IActionListRepository _actionListRepository;
        private readonly ILogger<IActionListServices> _logger;

        public ActionListService(IActionListRepository actionListRepository, ILogger<IActionListServices> logger){
            _actionListRepository = actionListRepository;
            _logger = logger;

        }

        public async Task<bool> AddActionAsync(ActionCreateDTO? action){
            try{
                var mapper = new ActionListModel{
                    Id = action.Id,
                    Action = action.Action,
                    Name = action.Name,
                    TypeAction = action.TypeAction,
                    UserID = action.UserID
                };
                var response = await _actionListRepository.AddActionAsync(mapper);
                return response;

            }catch(Exception ex){
                _logger.LogError("An error while add action in service => exception:" + ex.Message);
                return false;

            }
        } 
        public async Task<ActionViewDTO> GetActionByID(int? id){
            try{
                var action = await _actionListRepository.GetActionByIdAsync(id);
                var mapper = new ActionViewDTO{
                    Name = action.Name,
                    Action = action.Action,
                };
                switch ((int)action.TypeAction){
                    case 0:
                        mapper.TypeAction = "Fazendo";
                        break;
                    case 1:
                        mapper.TypeAction = "Feito"; 
                        break;
                    case 2:
                        mapper.TypeAction = "A Fazer";
                        break; 
                };
                return mapper;

            }catch(Exception ex){
                _logger.LogError($"An error while get action by ID {id} in service => exception:" + ex.Message);
                return null;

            }
        }
        public async Task<ActionViewDTO> GetActionByID_User(int? id){
            try{
                var action = await _actionListRepository.GetActionByIdUserAsync(id);
                var mapper = new ActionViewDTO{
                    Name = action.Name,
                    Action = action.Action,
                };
                 switch ((int)action.TypeAction){
                    case 0:
                        mapper.TypeAction = "Fazendo";
                        break;
                    case 1:
                        mapper.TypeAction = "Feito"; 
                        break;
                    case 2:
                        mapper.TypeAction = "A Fazer";
                        break; 
                 };
                return mapper;

            }catch(Exception ex){
                _logger.LogError($"An error while get action by ID user {id} in service => exception:" + ex.Message);
                return null;

            }
        }
        public async Task<ActionViewDTO> GetActionByName(string? name){
            try{
                var action = await _actionListRepository.GetActionByNameAsync(name);
                var mapper = new ActionViewDTO{
                    Name = action.Name,
                    Action = action.Action,
                };
                 switch ((int)action.TypeAction){
                    case 0:
                        mapper.TypeAction = "Fazendo";
                        break;
                    case 1:
                        mapper.TypeAction = "Feito"; 
                        break;
                    case 2:
                        mapper.TypeAction = "A Fazer";
                        break; 
                 }
                return mapper;

            }catch(Exception ex){
                _logger.LogError($"An error while get action by name {name} in service => exception:" + ex.Message);
                return null;

            }
        }
        public async Task<IEnumerable<ActionViewDTO>> GetActionsByID_User(int? id){
            try{
                var actions = await _actionListRepository.GetActionsByIdUserAsync(id);
                var actions_List = new List<ActionViewDTO>();
                foreach(var action in actions){
                    var mapper = new ActionViewDTO{
                    Name = action.Name,
                    Action = action.Action,
                    };
                    switch ((int)action.TypeAction){
                    case 0:
                        mapper.TypeAction = "Fazendo";
                        break;
                    case 1:
                        mapper.TypeAction = "Feito"; 
                        break;
                    case 2:
                        mapper.TypeAction = "A Fazer";
                        break; 
                 }
                    actions_List.Add(mapper);
                }
               
                return actions_List;

            }catch(Exception ex){
                _logger.LogError($"An error while get action by ID user {id} in service => exception:" + ex.Message);
                return null;

            }
        }
        public async Task<IEnumerable<ActionViewDTO>> GetAllActions(){
            try{
                var actions = await _actionListRepository.GetAllActionsAsync();
                var actions_List = new List<ActionViewDTO>();
                foreach(var action in actions){
                    var mapper = new ActionViewDTO{
                    Name = action.Name,
                    Action = action.Action,
                    };
                    switch ((int)action.TypeAction){
                    case 0:
                        mapper.TypeAction = "Fazendo";
                        break;
                    case 1:
                        mapper.TypeAction = "Feito"; 
                        break;
                    case 2:
                        mapper.TypeAction = "A Fazer";
                        break; 
                 }
                    actions_List.Add(mapper);
                }
               
                return actions_List;

            }catch(Exception ex){
                _logger.LogError($"An error while get all actions in service => exception:" + ex.Message);
                return null;

            }
        }
        public async Task<bool> UpdateAction(ActionUpdateDTO? action){
            try{
                var mapper = new ActionListModel{
                    Id = action.Id,
                    Name = action.Name,
                    Action = action.Action,
                    TypeAction = action.TypeAction
                };
                
                var response = await _actionListRepository.UpdateActionAsync(mapper);
                return response;

            }catch(Exception ex){
                _logger.LogError($"An error while update action by ID {action.Id} in service => exception:" + ex.Message);
                return false;

            }
        }
        public async Task<bool> RemoveActionAsync(int? id){
            try{
                var response = await _actionListRepository.DeleteActionAdsync(id);
                return response;

            }catch(Exception ex){
                _logger.LogError($"An error while remove action by ID {id} in service => exception:" + ex.Message);
                return false;

            }
            
        }
    }
}