using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastruture.Data
{
    public class AppContextDB:DbContext
    {
        public AppContextDB(DbContextOptions<AppContextDB> options) : base(options){

        }

        public DbSet<ActionListModel> ActionModelSet { get; set; }
        public DbSet<UserModel>  UserModelSet { get; set; }
    }
}