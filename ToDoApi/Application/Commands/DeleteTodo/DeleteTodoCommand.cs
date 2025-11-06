using MediatR;

namespace ToDoApi.Application.Commands.DeleteTodo
{
    public record DeleteTodoCommand(int Id) : IRequest<bool>;
}