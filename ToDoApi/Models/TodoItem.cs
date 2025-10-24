namespace ToDoApi.Models
{
    public class TodoItem
    {
        public int Id { get; set; }           // 主键
        public string? Title { get; set; }    // 任务标题
        public bool IsComplete { get; set; }  // 是否完成
    }
}