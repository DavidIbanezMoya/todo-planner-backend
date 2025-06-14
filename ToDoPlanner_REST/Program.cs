using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDoPlanner_REST.Models;
using ToDoPlanner_REST.Data;
using ToDoPlanner_REST.DTO;
using ToDoPlanner_REST;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("TasksDB"));
builder.Services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("StatusDB"));
builder.Services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("UsersDB"));
builder.Services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("BoardsDB"));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
//Creating the AutoMapper
//We can call it directly without creating an instance, because it is an static method
var mapper = MapperConfig.InitializeAutoMapper();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
