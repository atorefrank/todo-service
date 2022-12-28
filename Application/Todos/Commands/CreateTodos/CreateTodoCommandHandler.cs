using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApi.Infrastructure.Persistence;
using TodoApi.Domain.Entities;

namespace TodoApi.Application.Todos.Commands.CreateTodos
{
    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand,Unit>
    {
        // Next we need handlers for the command.
        private readonly TodoContext _context;

        public CreateTodoCommandHandler(TodoContext context) => _context = context;

        public async Task<Unit> Handle(CreateTodoCommand command, CancellationToken cancellationToken)
        {
            var todo = new TodoItem
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                IsComplete = command.IsComplete
            };
            // save the object in the database
            _context.TodoItems.Add(todo);
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
        
    }
}