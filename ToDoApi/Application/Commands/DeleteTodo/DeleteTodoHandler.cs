using MediatR;

namespace ToDoApi.Application.Commands.DeleteTodo
{
    public class DeleteTodoHandler : IRequestHandler<DeleteTodoCommand, bool>
    {
        private readonly TodoContext _db;

        public DeleteTodoHandler(TodoContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            var item = await _db.TodoItems.FindAsync(request.Id);

            if (item == null)
                return false;  // 让 Controller 返回 404

            _db.TodoItems.Remove(item);
            await _db.SaveChangesAsync();

            return true;
        }
    }
}