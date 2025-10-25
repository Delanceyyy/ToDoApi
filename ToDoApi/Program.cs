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

// GET all  http://localhost:5175/todoitems
app.MapGet("/todoitems", async (TodoContext db) =>
    await db.TodoItems.ToListAsync());

// get by id
app.MapGet("/todoitems/{id}", async (int id, TodoContext db) =>
    await db.TodoItems.FindAsync(id)
        is TodoItem item
        ? Results.Ok(item)
        : Results.NotFound());

// POST
app.MapPost("/todoitems", async (TodoItem item, TodoContext db) =>
{
    db.TodoItems.Add(item);
    await db.SaveChangesAsync();
    return Results.Created($"/todoitems/{item.Id}", item);
});

// put
app.MapPut("/todoitems/{id}", async (int id, TodoItem updatedItem, TodoContext db) =>
{
    var item = await db.TodoItems.FindAsync(id);
    if (item is null) return Results.NotFound();

    item.Title = updatedItem.Title;
    item.IsComplete = updatedItem.IsComplete;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

// delete
app.MapDelete("/todoitems/{id}", async (int id, TodoContext db) =>
{
    var item = await db.TodoItems.FindAsync(id);
    if (item is null) return Results.NotFound();

    db.TodoItems.Remove(item);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();