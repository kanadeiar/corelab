using Microsoft.EntityFrameworkCore;
using WebApp;
using WebApp.Common;
using WebApp.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureServices(services =>
{
    services.AddDbContext<DataContext>(options => 
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("ProductConnection"));
        options.EnableSensitiveDataLogging(true);
    });
});

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseRouting();

app.UseMiddleware<TestMiddleware>();

app.MapGet("/", () => "Hello World!");

using (var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>())
{
    TestData.SeedDatabase(context);
}

app.Run();
