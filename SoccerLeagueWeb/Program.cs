using SoccerLeagueWeb.Data;
using Microsoft.EntityFrameworkCore;
using SoccerLeagueWeb.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar SeedDb como um serviço
builder.Services.AddTransient<SeedDb>();

// Configura a injeção de dependência para repositórios
builder.Services.AddScoped<IClubRepository, ClubRepository>();

var app = builder.Build();

// Execute o SeedDb para popular o banco de dados
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var seedDb = services.GetRequiredService<SeedDb>();
        await seedDb.SeedAsync(); 
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error executing SeedDb: {ex.Message}");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
