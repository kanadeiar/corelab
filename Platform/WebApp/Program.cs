using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApp;
using WebApp.Data;
using WebApp.Mapping;
using WebApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureServices(services =>
{
    services.AddDbContext<DataContext>(options => 
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("ProductConnection"));
        options.EnableSensitiveDataLogging(true);
    });

    services.AddControllersWithViews().AddRazorRuntimeCompilation();
    services.AddRazorPages().AddRazorRuntimeCompilation();

    services.AddDistributedMemoryCache();
    services.AddSession(options =>
    {
        options.Cookie.IsEssential = true;
    });
    services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "WebApp", Version = "v1" });
    });

    var mapperConfig = new MapperConfiguration(options => options.AddProfile<DataMappingProfile>());
    services.AddSingleton<IMapper>(x => mapperConfig.CreateMapper());

    services.AddSingleton<CitiesData>();
});

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApp");
});

app.MapDefaultControllerRoute();
app.MapRazorPages();

using (var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>())
{
    TestData.SeedDatabase(context);
}

app.Run();
