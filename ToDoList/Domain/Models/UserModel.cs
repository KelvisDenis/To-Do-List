using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Domain.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public UserModel(){}
        public UserModel(int id, string? name, string? email, string? password){
            Id = id;
            Name = name;
            Email = email;
        }
    }
}