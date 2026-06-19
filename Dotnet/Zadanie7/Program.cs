using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ZadaniaZespolu.Data;
using ZadaniaZespolu.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ZadaniaZespoluContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ZadaniaZespoluContext")
        ?? throw new InvalidOperationException("Connection string 'ZadaniaZespoluContext' not found.")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Utworzenie bazy danych.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
