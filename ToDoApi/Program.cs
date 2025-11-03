using Microsoft.EntityFrameworkCore;
using ToDoApi;
using ToDoApi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<TodoService>();

// ✅ 1. 注册 EF Core DbContext
builder.Services.AddDbContext<TodoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ 2. 注册 Controllers（非常关键！）
builder.Services.AddControllers();

var app = builder.Build();

// ✅ 3. HTTPS & 路由
app.UseHttpsRedirection();

// ✅ 4. 映射 Controller 路由
app.MapControllers();

app.Run();