using MediatR;

namespace ToDoApi.Application.Commands.AddTodo
{
    public class AddTodoCommand : IRequest<int>   // 返回新记录的 Id
    {
        public string Title { get; set; }
        public bool IsComplete { get; set; }
        public int? CategoryId { get; set; }   // 如果未来要支持分类
    }
}