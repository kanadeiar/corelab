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
});

var app = builder.Build();
const string baseUrl = "api/product";

app.MapGet(baseUrl, async (HttpContext context, DataContext data) => 
{
    context.Response.ContentType = "application/json";
    await context.Response.WriteAsync(JsonSerializer.Serialize<IEnumerable<Product>>(data.Products));
});

app.MapGet($"{baseUrl}/{{id}}", async (HttpContext context, DataContext data) =>
{
    var id = context.Request.RouteValues["id"] as string;
    if (id is { })
    {
        var product = data.Products.Find(int.Parse(id));
        if (product is { })
        {
            context.Response.ContentType="application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize<Product>(product));
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
        }
    }
    else
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
    }
});

app.MapPost($"{baseUrl}", async (HttpContext context, DataContext data) => 
{
    var product = await JsonSerializer.DeserializeAsync<Product>(context.Request.Body);
    //var product = new Product { Name = "Test", Price = 12.2M, CategoryId = 1, SupplierId = 1 };
    if (product is { })
    {
        data.Add(product);
        await data.SaveChangesAsync();
        context.Response.StatusCode = StatusCodes.Status200OK;
    }
    else
    {
        context.Response.StatusCode = StatusCodes.Status404NotFound;
    }
});

//app.UseDeveloperExceptionPage();
//app.UseStaticFiles();
//app.UseRouting();

//app.UseMiddleware<TestMiddleware>();

app.MapGet("/", () => "Hello World!");

using (var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>())
{
    TestData.SeedDatabase(context);
}

app.Run();
