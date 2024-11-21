using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Application.DTOs.ActionListDTOs;

namespace ToDoList.Application.Services.Interface
{
    public interface IActionListServices
    {
        Task<bool> AddActionAsync(ActionCreateDTO? action);
        Task<ActionViewDTO> GetActionByID(int? id);
        Task<ActionViewDTO> GetActionByID_User(int? id);
        Task<ActionViewDTO> GetActionByName(string? name);
        Task<IEnumerable<ActionViewDTO>> GetActionsByID_User(int? id);
        Task<IEnumerable<ActionViewDTO>> GetAllActions();
        Task<bool> UpdateAction(ActionUpdateDTO? action);
        Task<bool> RemoveActionAsync(int? id);
    }
}