using Microsoft.EntityFrameworkCore;
using ToDoApi.Entity;
using ToDoApi.Models;

namespace ToDoApi.Services
{
    public class TodoService
    {
        private readonly TodoContext _context;

        public TodoService(TodoContext context)
        {
            _context = context;
        }

        public async Task<List<TodoItem>> GetAllAsync()
        {
            return await _context.TodoItems.ToListAsync();
        }

        public async Task<TodoItem?> GetByIdAsync(int id)
        {
            return await _context.TodoItems.FindAsync(id);
        }

        public async Task<TodoItem> CreateAsync(TodoItemDto dto)
        {
            var item = new TodoItem
            {
                Title = dto.Title,
                IsComplete = dto.IsComplete
            };

            _context.TodoItems.Add(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<bool> UpdateAsync(int id, TodoItemDto dto)
        {
            var existing = await _context.TodoItems.FindAsync(id);

            if (existing == null)
                return false;

            existing.Title = dto.Title;
            existing.IsComplete = dto.IsComplete;

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