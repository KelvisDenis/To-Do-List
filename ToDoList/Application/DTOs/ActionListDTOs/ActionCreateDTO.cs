using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Domain.Enums;

namespace ToDoList.Application.DTOs.ActionListDTOs
{
    public class ActionCreateDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Action { get; set; }
        public TypeActionEnum? TypeAction { get; set; }
        public int UserID { get; set; }

        public ActionCreateDTO(){}
        public ActionCreateDTO(int id, string? name, string? action, TypeActionEnum? typeAction, int userID){
            Id = id;
            Name = name;
            Action = action;
            TypeAction = typeAction;
            UserID = userID;
        }

    }
}