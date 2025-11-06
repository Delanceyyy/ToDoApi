using MediatR;
using ToDoApi.Entity;


namespace ToDoApi.Application.Commands.AddTodo
{
    public class AddTodoHandler : IRequestHandler<AddTodoCommand, int>
    {
        private readonly TodoContext _context;

        public AddTodoHandler(TodoContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = new TodoItem
            {
                Title = request.Title,
                IsComplete = request.IsComplete,
                CategoryId = request.CategoryId
            };

            _context.TodoItems.Add(todo);
            await _context.SaveChangesAsync(cancellationToken);

            return todo.Id;
        }
    }
}