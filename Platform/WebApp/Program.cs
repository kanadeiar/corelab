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

    services.AddControllers().AddNewtonsoftJson()/*.AddXmlSerializerFormatters()*/;

    //services.Configure<JsonOptions>(options =>
    //{
    //    options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    //});
    services.Configure<MvcNewtonsoftJsonOptions>(options =>
    {
        options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
    });
    services.Configure<MvcOptions>(options =>
    {
        options.RespectBrowserAcceptHeader = true;
        options.ReturnHttpNotAcceptable = true;
    });
    services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "WebApp", Version = "v1" });
    });
});

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseRouting();
app.UseMiddleware<TestMiddleware>();



app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApp");
});

using (var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>())
{
    TestData.SeedDatabase(context);
}

app.Run();
