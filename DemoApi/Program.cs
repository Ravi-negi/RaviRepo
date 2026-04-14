var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("AllowAll");

// 👉 Enable static files (IMPORTANT)
app.UseDefaultFiles();
app.UseStaticFiles();

// API endpoint
app.MapGet("/api/hello", () =>
{
    return new { message = "Hello from .NET API 🚀" };
});

// 👉 Fallback to React index.html
app.MapFallbackToFile("index.html");

app.Run();