using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;

var builder = WebApplication.CreateBuilder(args);

// קבלת מחרוזת חיבור מה-ENV
var dbConnectionString = Environment.GetEnvironmentVariable("DB_CSTR")
    ?? "Server=mariadb;Database=sampledb;User=admin;Password=Aa1234561!;";

// הגדרת DbContext עם MySQL/MariaDB
builder.Services.AddDbContext<TodoDb>(options =>
    options.UseMySql(dbConnectionString, ServerVersion.AutoDetect(dbConnectionString)));

// Add services to the container.
builder.Services.AddControllers();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// יצירת הטבלאות אוטומטית (Migration)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TodoDb>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseCors(); // Enable CORS
app.UseAuthorization();

app.MapControllers();

app.Run();
