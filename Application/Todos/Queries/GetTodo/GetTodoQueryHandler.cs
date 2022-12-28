using System.Threading;
using System.Collections;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApi.Domain.Entities;
using TodoApi.Infrastructure.Persistence;

namespace TodoApi.Application.Todos.Queries.GetTodo
{
    public class GetTodoQueryHandler : IRequestHandler<GetTodoQuery, IEnumerable<TodoItem>>
    {
        private readonly TodoContext _context;
        public GetTodoQueryHandler(TodoContext context) => _context = context;

        public async Task<IEnumerable<TodoItem>> Handle(GetTodoQuery request, CancellationToken cancellationToken) => await _context.TodoItems.ToListAsync();
    }
}