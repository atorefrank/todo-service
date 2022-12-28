using MediatR;

namespace TodoApi.Application.Todos.Commands.CreateTodos
{
    public class CreateTodoCommand : IRequest
    {
        //Basically a message if we think about traditional messaging systems. Let’s go ahead and just create a blank object (command) that inherits from IRequest  (An inbuilt type of MediatR).
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}