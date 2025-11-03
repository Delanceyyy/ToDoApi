namespace ToDoApi.Entity
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public bool IsComplete { get; set; }
        
        // 外键（可空）：给已有数据一个过渡空间，避免迁移时因历史数据没有分类而失败
        public int? CategoryId { get; set; }

        // 导航属性：指向 1 个 Category
        public Category? Category { get; set; }
    }
}

