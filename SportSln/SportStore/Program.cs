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

    services.AddRazorPages();
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

app.MapControllerRoute("catpage", "{category}/Page{page:int}", new { Controller = "Home", Action = "Index" });
app.MapControllerRoute("page", "Page{page:int}", new { Controller = "Home", Action = "Index", Page = 1 });
app.MapControllerRoute("category", "{category}", new { Controller = "Home", Action = "Index", Page = 1 });
app.MapControllerRoute("pagination", "Products/Page{page}", new { Controller = "Home", Action = "Index", Page = 1 });
app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();

public partial class Program { }