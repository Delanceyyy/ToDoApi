using Microsoft.EntityFrameworkCore;
using ToDoApi.Entity;
using ToDoApi.Models;

namespace ToDoApi.Services
{
    public class TodoService : ITodoService
    {
        private readonly TodoContext _context;

        public TodoService(TodoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoItemDto>> GetAllAsync()
        {
            return await _context.TodoItems
                .Include(t => t.Category)
                .Select(t => new TodoItemDto
                {
                    Title = t.Title,
                    IsComplete = t.IsComplete,
                    CategoryName = t.Category != null ? t.Category.Name : null,
                    CategoryColor = t.Category != null ? t.Category.Color : null
                })
                .ToListAsync();
        }

        public async Task<TodoItemDto?> GetByIdAsync(int id)
        {
            return await _context.TodoItems
                .Include(t => t.Category)
                .Where(t => t.Id == id)
                .Select(t => new TodoItemDto
                {
                    Title = t.Title,
                    IsComplete = t.IsComplete,
                    CategoryName = t.Category != null ? t.Category.Name : null,
                    CategoryColor = t.Category != null ? t.Category.Color : null
                })
                .FirstOrDefaultAsync();
        }

        public async Task<TodoItem> CreateAsync(CreateTodoDto dto)
        {
            var item = new TodoItem
            {
                Title = dto.Title,
                IsComplete = dto.IsComplete,
                CategoryId = dto.CategoryId
            };

            _context.TodoItems.Add(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<bool> UpdateAsync(int id, UpdateTodoDto dto)
        {
            var existing = await _context.TodoItems.FindAsync(id);

            if (existing == null)
                return false;

            existing.Title = dto.Title;
            existing.IsComplete = dto.IsComplete;
            existing.CategoryId = dto.CategoryId; 

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _context.TodoItems.FindAsync(id);

            if (item == null)
                return false;

            _context.TodoItems.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
