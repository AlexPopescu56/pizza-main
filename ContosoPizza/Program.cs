using ContosoPizza.Data;
using ContosoPizza.Services;
using Microsoft.EntityFrameworkCore;
 
var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddRazorPages();
 
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<PizzaContext>(options =>
        options.UseSqlite("Data Source=ContosoPizza.db"));
    Console.WriteLine("Using SQLite for development");
}
else
{
    // Use Azure SQL Database for production
    var connectionString = builder.Configuration.GetConnectionString("AzureSqlConnection");
    builder.Services.AddDbContext<PizzaContext>(options =>
        options.UseSqlServer(connectionString));
    Console.WriteLine("Using Azure SQL Database for production");
}
 
builder.Services.AddScoped<PizzaService>();
 
var app = builder.Build();
 
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
 
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
 
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PizzaContext>();
    try
    {
        if (app.Environment.IsDevelopment())
        {
            context.Database.EnsureCreated();
            Console.WriteLine("SQLite database initialized successfully!");
        }
        else
        {
            context.Database.Migrate();
            Console.WriteLine("Azure SQL Database migrated successfully!");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Database initialization failed: {ex.Message}");
    }
}
 
app.Run();