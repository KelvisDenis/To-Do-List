using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastruture.Repository.Interfaces
{
    public interface IActionListRepository
    {
        Task<bool> AddActionAsync(ActionListModel? action);
        Task<ActionListModel> GetActionByIdAsync(int? id);
        Task<ActionListModel> GetActionByNameAsync(string? name);
        Task<ActionListModel> GetActionByIdUserAsync(int? id);
        Task<IEnumerable<ActionListModel>> GetActionsByIdUserAsync(int? id);
        Task<IEnumerable<ActionListModel>> GetAllActionsAsync();
        Task<bool> UpdateActionAsync(ActionListModel? action);
        Task<bool> DeleteActionAdsync(int? id);

    }
}