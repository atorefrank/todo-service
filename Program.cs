using Microsoft.EntityFrameworkCore;
using MediatR;
using TodoApi.Infrastructure.Persistence;
using TodoApi.Application.Todos.Commands.CreateTodos;
using TodoApi.Application.Todos.Queries.GetTodo;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseInMemoryDatabase("TodoList"));

// Add commands handlers
// builder.Services.AddScoped<ICommandHandler<CreateTodoCommand>, CreateTodoCommandHandler>();
// In our ConfigureServices method, we need to add in a call to register all of MediatR’s dependencies.
builder.Services.AddMediatR(new Type[] 
{ 
  typeof(CreateTodoCommand),
  typeof(GetTodoQuery)
 
});

//MediatR finds all handlers within the assembly and registers them correctly
// services.AddMediatR(Assembly.GetExecutingAssembly());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
