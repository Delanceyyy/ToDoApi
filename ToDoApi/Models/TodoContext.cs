using Microsoft.EntityFrameworkCore;

namespace ToDoApi.Models
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
                new TodoItem { Id = 4, Title = "4", IsComplete = false }
            );
        }
    }
}