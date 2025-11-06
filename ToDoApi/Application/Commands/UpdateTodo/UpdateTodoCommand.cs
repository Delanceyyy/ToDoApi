using MediatR;

namespace ToDoApi.Application.Commands.UpdateTodo
{
    public record UpdateTodoCommand(int Id, string Title, bool IsComplete, int? CategoryId) : IRequest<bool>;
}










