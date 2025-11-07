using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Models;

namespace ToDoApi.Application.Queries.Todo.GetTodos
{
    public record GetTodoByIdQuery(int Id) : IRequest<TodoItemDto?>;

    public class GetTodoByIdQueryHandler : IRequestHandler<GetTodoByIdQuery, TodoItemDto?>
    {
        private readonly TodoContext _db;

        public GetTodoByIdQueryHandler(TodoContext db)
        {
            _db = db;
        }

        public async Task<TodoItemDto?> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
        {
            return await _db.TodoItems
                .Where(x => x.Id == request.Id)
                .Select(x => new TodoItemDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    IsComplete = x.IsComplete,
                    CategoryName = x.Category.Name,
                    CategoryColor = x.Category.Color,
                    CategoryId = x.CategoryId
                })
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}