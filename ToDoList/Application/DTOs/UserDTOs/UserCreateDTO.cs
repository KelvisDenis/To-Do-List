using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Application.DTOs.UserDTOs
{
    public class UserCreateDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public UserCreateDTO(){}
        public UserCreateDTO(int id, string? name, string? email, string? password){
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            
        }

    }
}