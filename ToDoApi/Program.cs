using Microsoft.EntityFrameworkCore;
using ToDoApi;
using ToDoApi.Services;

var builder = WebApplication.CreateBuilder(args);

// ✅ 注册 DbContext
builder.Services.AddDbContext<TodoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ 注入 Service
builder.Services.AddScoped<ITodoService, TodoService>();

// ✅ 注册控制器
builder.Services.AddControllers();

var app = builder.Build();

// ✅ 启用 HTTPS
app.UseHttpsRedirection();

// ✅ 映射 Controller 路由
app.MapControllers();

app.Run();