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

        //migration data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().HasData(
                new TodoItem { Id = 1, Title = "1", IsComplete = false },
                new TodoItem { Id = 2, Title = "Learn EF Core", IsComplete = false },
                new TodoItem { Id = 3, Title = "Build API", IsComplete = true },
                new TodoItem { Id = 4, Title = "4", IsComplete = false },
                new TodoItem { Id = 8, Title = "8", IsComplete = false }
            );
        }
    }
}