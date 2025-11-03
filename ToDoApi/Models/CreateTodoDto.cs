// 用于post

namespace ToDoApi.Models
{
    public class CreateTodoDto
    {
        public string Title { get; set; } = string.Empty;
        public bool IsComplete { get; set; }
        public int? CategoryId { get; set; }   
    }
}