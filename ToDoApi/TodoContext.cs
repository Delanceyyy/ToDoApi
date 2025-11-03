using Microsoft.EntityFrameworkCore;
using ToDoApi.Entity;

namespace ToDoApi   //👈 这一行是必须的
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!; 

        //migration data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1) 关系映射：一个 Category 拥有多个 TodoItem；TodoItem 的外键是 CategoryId（可空）
            modelBuilder.Entity<TodoItem>()
                .HasOne(t => t.Category)
                .WithMany(c => c.Todos)
                .HasForeignKey(t => t.CategoryId);
            
            // 2) 种子 Category（你可以改名字/颜色）
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Study", Description = "Learning-related tasks", Color = "Blue" },
                new Category { Id = 2, Name = "Work",  Description = "Work-related tasks",     Color = "Red"  },
                new Category { Id = 3, Name = "other",  Description = "other things",     Color = "Green"  }
            );
            
            modelBuilder.Entity<TodoItem>().HasData(
                new TodoItem { Id = 1, Title = "1",             IsComplete = false, CategoryId = 3 },
                new TodoItem { Id = 2, Title = "Learn EF Core", IsComplete = false, CategoryId = 1 },
                new TodoItem { Id = 3, Title = "Build API",     IsComplete = true,  CategoryId = 2 },
                new TodoItem { Id = 4, Title = "4",             IsComplete = false, CategoryId = 3 },
                new TodoItem { Id = 8, Title = "8",             IsComplete = false, CategoryId = 1 }
            );
        }
    }
}