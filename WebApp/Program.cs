using Microsoft.EntityFrameworkCore;
using WebApp.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Get environment variables
var dbServer = Environment.GetEnvironmentVariable("DB_SERVER") ?? "localhost";
var dbDatabase = Environment.GetEnvironmentVariable("DB_DATABASE") ?? "MyDb";
var dbUser = Environment.GetEnvironmentVariable("DB_USER") ?? "sa";
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "Password123!";

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var defaultConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    
    System.Console.WriteLine("Is defaultConnectionString null or empty?");
    System.Console.WriteLine(string.IsNullOrEmpty(defaultConnectionString));

    if (string.IsNullOrEmpty(defaultConnectionString))
    {
        throw new InvalidOperationException("Connection string not found.");
    }
    
    defaultConnectionString = defaultConnectionString
        .Replace("${DB_SERVER}", dbServer)
        .Replace("${DB_DATABASE}", dbDatabase)
        .Replace("${DB_USER}", dbUser)
        .Replace("${DB_PASSWORD}", dbPassword);
    
    System.Console.WriteLine($"Connection string: {defaultConnectionString}");

    options.UseSqlServer(defaultConnectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();