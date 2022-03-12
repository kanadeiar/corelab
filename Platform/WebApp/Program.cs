using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using WebApp;
using WebApp.Common;
using WebApp.Data;
using WebApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureServices(services =>
{
    services.AddDbContext<DataContext>(options => 
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("ProductConnection"));
        options.EnableSensitiveDataLogging(true);
    });

    services.AddControllers();
});

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseRouting();

app.MapControllers();

app.MapDefaultControllerRoute();

using (var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>())
{
    TestData.SeedDatabase(context);
}

app.Run();
