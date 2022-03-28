
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PersonsConnection"));
    options.EnableSensitiveDataLogging();    
});
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles("/blazor");
app.UseStaticFiles();

app.UseRouting();
app.MapControllers();
app.MapDefaultControllerRoute();
app.MapRazorPages();

app.MapFallbackToFile("/blazor/{*path:nonfile}", "/blazor/index.html");

using (var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>())
{
    TestData.SeedTestData(context);
}

app.Run();
