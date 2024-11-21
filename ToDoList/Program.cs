using Microsoft.EntityFrameworkCore;
using ToDoList.Application.Services.Implementation;
using ToDoList.Application.Services.Interface;
using ToDoList.Infrastruture.Data;
using ToDoList.Infrastruture.Repository.Implementation;
using ToDoList.Infrastruture.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<AppContextDB>(op => op.UseInMemoryDatabase("TODODB"));

// add scoped repository
builder.Services.AddScoped<IActionListRepository, ActionListRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// add scoped service
builder.Services.AddScoped<IActionListServices, ActionListService>();
builder.Services.AddScoped<IUserService, UserService>();
// Add cors especify
builder.Services.AddCors(op => {op.AddPolicy(
    "AllowSpecifyOrigin", builder => {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    }
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseSwaggerUI();
}

// Ensure CORS is enabled before routing
app.UseCors("AllowSpecifyOrigin");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
// Map controllers and endpoints
app.MapControllers();

app.Run();