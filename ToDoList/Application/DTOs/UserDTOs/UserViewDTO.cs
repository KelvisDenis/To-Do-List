using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Application.DTOs.UserDTOs
{
    public class UserViewDTO
    {
        public string? Name { get; set; }
        public string? Email { get; set; }

        public UserViewDTO(){}
        public UserViewDTO(string? name, string? email){
            Name = name;
            Email = email;
            
        }
    }
}