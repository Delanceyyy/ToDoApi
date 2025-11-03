namespace ToDoApi.Models
{
    public class TodoItemDto
    {
        public string? Title { get; set; }
        public bool IsComplete { get; set; }
        
        // ✅ 新字段：给前端展示 Category 名称
        public string? CategoryName { get; set; }
        public string? CategoryColor { get; set; }
    }
}