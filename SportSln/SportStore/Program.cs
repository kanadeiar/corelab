var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureServices(services =>
{
    services.AddDbContext<StoreDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("SportStoreConnection"));
        //options.UseSqlite(builder.Configuration.GetConnectionString("SportStoreConnection"));
    });
    services.AddDbContext<AppIdentityDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
        //options.UseSqlite(builder.Configuration.GetConnectionString("IdentityConnection"));
    });
    services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<AppIdentityDbContext>();
    services.AddControllersWithViews().AddRazorRuntimeCompilation();
    services.AddRazorPages();
    services.AddServerSideBlazor();
    services.AddDistributedMemoryCache();
    services.AddSession();

    services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    services.AddScoped<IStoreRepository, EFStoreRepository>();
    services.AddScoped<IOrderRepository, EFOrderRepository>();

    services.AddScoped<Cart>(x => SessionCart.GetCart(x));

    services.AddTransient<ISeedTestData, SeedTestData>();
    services.AddTransient<IIdentitySeedTestData, IdentitySeedTestData>();
});

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 3;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;
    options.User.RequireUniqueEmail = true;
    options.User.AllowedUserNameCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    await scope.ServiceProvider
        .GetRequiredService<IIdentitySeedTestData>()
        .SeedData(app.Services, builder.Configuration);
    await scope.ServiceProvider
        .GetRequiredService<ISeedTestData>()
        .SeedData(app.Services, builder.Configuration);
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseStatusCodePages();
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseStatusCodePages();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//app.MapControllerRoute("catpage", "{category}/Page{page:int}", new { Controller = "Home", Action = "Index" });
//app.MapControllerRoute("page", "Page{page:int}", new { Controller = "Home", Action = "Index", Page = 1 });
//app.MapControllerRoute("pagination", "Products/Page{page}", new { Controller = "Home", Action = "Index", Page = 1 });
app.MapDefaultControllerRoute();
app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index");

app.Run();

public partial class Program { }