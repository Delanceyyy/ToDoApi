namespace ToDoApi.Entity
{
    public class Category
    {
        public int Id { get; set; }                 // 主键
        public string Name { get; set; } = "";      // 分类名：Study / Work ...
        public string? Description { get; set; }    // 说明：可空
        public string? Color { get; set; }          // 颜色名/代码：可空

        // 反向导航（1 -> 多），不会生成列，只是关系映射
        public ICollection<TodoItem> Todos { get; set; } = new List<TodoItem>();
    }
}