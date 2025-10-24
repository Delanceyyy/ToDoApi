using Microsoft.EntityFrameworkCore;
using ToDoApi.Models;

var builder = WebApplication.CreateBuilder(args);

// ✅ 从 appsettings.json 加载连接字符串
builder.Services.AddDbContext<TodoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ 可选：添加 OpenAPI（Swagger）
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


// GET
app.MapGet("/todoitems", async (TodoContext db) =>
    await db.TodoItems.ToListAsync());

// POST
app.MapPost("/todoitems", async (TodoItem item, TodoContext db) =>
{
    db.TodoItems.Add(item);
    await db.SaveChangesAsync();
    return Results.Created($"/todoitems/{item.Id}", item);
});

app.Run();