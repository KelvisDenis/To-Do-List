using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Domain.Enums;

namespace ToDoList.Domain.Models
{
    public class ActionListModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Action { get; set; }
        public TypeActionEnum? TypeAction { get; set; }
        public int UserID { get; set; }


        public ActionListModel(){}
        public ActionListModel(int id, string? name, string? action, TypeActionEnum? typeAction, int userId){
            Id = id;
            Name = name;
            Action = action;
            TypeAction = typeAction;
            UserID = userId;
        }
    }
}