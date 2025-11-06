using MediatR;


namespace ToDoApi.Application.Commands.UpdateTodo
{
    public class UpdateTodoHandler : IRequestHandler<UpdateTodoCommand, bool>
    {
        private readonly TodoContext _db;

        public UpdateTodoHandler(TodoContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            var item = await _db.TodoItems.FindAsync(request.Id);

            if (item == null)
                return false;

            // Update fields
            item.Title = request.Title;
            item.IsComplete = request.IsComplete;
            if (request.CategoryId.HasValue)
            {
                item.CategoryId = request.CategoryId.Value;   // 只有传了才更新分类
            }

            await _db.SaveChangesAsync();
            return true;
        }
    }
}