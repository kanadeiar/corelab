using AutoMapper;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using WebApp;
using WebApp.Data;
using WebApp.Filters;
using WebApp.Mapping;
using WebApp.Models;
//using WebApp.TagHelpers;

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

    services.Configure<MvcOptions>(options => options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(value => "¬ведите значение"));

    services.AddScoped<GuidResponseAttribute>();
    //services.Configure<MvcOptions>(options =>
    //{
    //    options.Filters.Add<HttpsOnlyAttribute>();
    //    options.Filters.Add(new MessageAttribute("This is the globally-scoped filter"));
    //});
    //services.Configure<MvcOptions>(options => options
    //    .Filters.Add<HttpsOnlyAttribute>());
});

var app = builder.Build();

MappingExtensions.Configure(app.Services.GetRequiredService<IMapper>());

app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApp");    
});

app.MapControllers();
//app.MapControllerRoute("forms", "controllers/{controller=Home}/{action=Index}/{id?}");
app.MapDefaultControllerRoute();
app.MapRazorPages();

using (var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>())
{
    TestData.SeedDatabase(context);
}

app.Run();
