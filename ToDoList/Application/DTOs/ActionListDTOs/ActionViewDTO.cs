using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Domain.Enums;

namespace ToDoList.Application.DTOs.ActionListDTOs
{
    public class ActionViewDTO
    {

        public string? Name { get; set; }
        public string? Action { get; set; }
        public string? TypeAction { get; set; }

        public ActionViewDTO(){}
        public ActionViewDTO(string? name, string? action, string? type){
            Name = name;
            Action = action;
            TypeAction = type;
            
        }
    }
}