var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureServices(services =>
{
    services.AddDbContext<StoreDbContext>(options =>
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("SportStoreConnection"));
    });
    services.AddControllersWithViews().AddRazorRuntimeCompilation();

    services.AddScoped<IStoreRepository, EFStoreRepository>();

    services.AddTransient<ISeedTestData, SeedTestData>();
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider
        .GetRequiredService<ISeedTestData>()
        .SeedData(app.Services, builder.Configuration);
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}

app.UseStatusCodePages();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute("pagination", "Products/Page{page}", new { Controller = "Home", Action = "Index" });
app.MapDefaultControllerRoute();

app.Run();

public partial class Program { }