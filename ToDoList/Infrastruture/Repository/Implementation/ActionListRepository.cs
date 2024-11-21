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
    public class ActionListRepository: IActionListRepository
    {
        private readonly AppContextDB _appContextDB;
        private readonly ILogger<IActionListRepository> _logger;

        public ActionListRepository(AppContextDB appContextDB, ILogger<IActionListRepository> logger){
            _appContextDB = appContextDB;
            _logger = logger;

        }

        public async Task<bool> AddActionAsync(ActionListModel? action){
            try{
                _appContextDB.ActionModelSet.Add(action);
                await _appContextDB.SaveChangesAsync();
                return true;

            }catch(Exception ex){
                _logger.LogError("An error while add action in repository ==> " + ex.Message);
                return false;
            }
        }
        public async Task<ActionListModel> GetActionByIdAsync(int? id){
             try{
                var action = await _appContextDB.ActionModelSet.FindAsync(id);
                return action;

            }catch(Exception ex){
                _logger.LogError($"An error while find action by id {id} in repository ==> " + ex.Message);
                return null;
            }
        }
        public async Task<ActionListModel> GetActionByNameAsync(string? name){
            try{
                var action = await _appContextDB.ActionModelSet.FirstOrDefaultAsync(x => x.Name == name);
                return action;

            }catch(Exception ex){
                _logger.LogError($"An error while find action by name {name} in repository ==> " + ex.Message);
                return null;
            }
        }
        public async Task<ActionListModel> GetActionByIdUserAsync(int? id){
            try{
                var action = await _appContextDB.ActionModelSet.FirstOrDefaultAsync(x => x.UserID == id);
                return action;

            }catch(Exception ex){
                _logger.LogError($"An error while find action by id user {id} in repository ==> " + ex.Message);
                return null;
            }
        }
        public async Task<IEnumerable<ActionListModel>> GetActionsByIdUserAsync(int? id){
             try{
                var action = await _appContextDB.ActionModelSet.Where(x => x.UserID == id).ToListAsync();
                return action;

            }catch(Exception ex){
                _logger.LogError($"An error while find actions by id user {id} in repository ==> " + ex.Message);
                return null;
            }
        }
        public async Task<IEnumerable<ActionListModel>> GetAllActionsAsync(){
             try{
                var action = await _appContextDB.ActionModelSet.ToListAsync();
                return action;

            }catch(Exception ex){
                _logger.LogError($"An error while find all actions in repository ==> " + ex.Message);
                return null;
            }
        }
        public async Task<bool> UpdateActionAsync(ActionListModel? action){
             try{
                var anny = await _appContextDB.ActionModelSet.AnyAsync(x => x.Id == action.Id);
                if(anny == false) throw new Exception($"Not Found action model by id {action.Id} for update");
                _appContextDB.ActionModelSet.Update(action);
                await _appContextDB.SaveChangesAsync();
                return true;

            }catch(Exception ex){
                _logger.LogError($"An error while update action by id {action.Id} in repository ==> " + ex.Message);
                return false;
            }
        }
        public async Task<bool> DeleteActionAdsync(int? id){
             try{
                var action = await _appContextDB.ActionModelSet.FindAsync(id);
                _appContextDB.ActionModelSet.Remove(action);
                await _appContextDB.SaveChangesAsync();
                return true;

            }catch(Exception ex){
                _logger.LogError($"An error while remove action by id {id} in repository ==> " + ex.Message);
                return false;
            }
        }

    }
}