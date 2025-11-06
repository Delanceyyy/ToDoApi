using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Models;        // ✅ DTO


namespace ToDoApi.Application.Queries.Todo.GetTodos
{
    // Query：请求一个 List<TodoItemDto>
    public record GetTodosQuery : IRequest<List<TodoItemDto>>;

    public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, List<TodoItemDto>>
    {
        private readonly TodoContext _db;

        public GetTodosQueryHandler(TodoContext db)
        {
            _db = db;
        }

        public async Task<List<TodoItemDto>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
        {
            return await _db.TodoItems
                .Select(x => new TodoItemDto
                {
                    //Id = x.Id,
                    Title = x.Title,
                    IsComplete = x.IsComplete,
                    CategoryName = x.Category.Name,
                    CategoryColor = x.Category.Color
                    //CategoryId = x.CategoryId
                })
                .ToListAsync(cancellationToken);
        }
    }
}