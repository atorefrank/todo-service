using MediatR;
using TodoApi.Domain.Entities;
using System.Collections;

namespace TodoApi.Application.Todos.Queries.GetTodo
{
    public class GetTodoQuery : IRequest<IEnumerable<TodoItem>>
    {
        public Guid Id  { get; set; }
        public string Name  { get; set; }
        public bool IsComplete  { get; set; }
    }
        
}