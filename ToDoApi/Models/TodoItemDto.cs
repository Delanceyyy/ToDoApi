namespace ToDoApi.Models
{
    public class TodoItemDto
    {
        //public int Id { get; set; }
        public string? Title { get; set; }
        public bool IsComplete { get; set; }
        
        // ✅ 新字段：给前端展示 Category 名称
        //public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryColor { get; set; }
    }
}