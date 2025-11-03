namespace ToDoApi.Models
{
    public class UpdateTodoDto
    {
        public string Title { get; set; } = string.Empty;
        public bool IsComplete { get; set; }
        public int? CategoryId { get; set; }
    }
}