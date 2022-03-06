var builder = WebApplication.CreateBuilder(args);

//builder.Services.Configure<CookiePolicyOptions>(options =>
//{
//    options.CheckConsentNeeded = context => true;
//});
//var servicesConfig = builder.Configuration;
//var servicesEnv = builder.Environment;
//builder.Services.Configure<MessageOptions>(servicesConfig.GetSection("Location"));

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => 
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.IsEssential = true;
});
builder.Services.AddHsts(options =>
{
    options.MaxAge = TimeSpan.FromDays(1);
    options.IncludeSubDomains = true;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}

//app.UseCookiePolicy();

app.UseHttpsRedirection();
app.UseSession();

app.UseMiddleware<ConsentMiddleware>();
app.UseRouting();

//var pipelineConfig = app.Configuration;
//var pipelineEnv = app.Environment;

//app.UseHttpLogging();

//app.UseStaticFiles();

//app.UseMiddleware<LocationMiddleware>();

//app.MapGet("config", async (HttpContext context, IConfiguration config, IWebHostEnvironment env) =>
//{
//    var defDebug = pipelineConfig["Logging:LogLevel:Default"];
//    await context.Response.WriteAsync($"The config settings is {defDebug}\n");
//    string environ = config["ASPNETCORE_ENVIRONMENT"];
//    await context.Response.WriteAsync($"The env settings is: {environ}\n");
//    await context.Response.WriteAsync($"The env is {env.EnvironmentName}\n");
//    var wsId = config["WebService:Id"];
//    var wsKey = config["WebService:Key"];
//    await context.Response.WriteAsync($"\nThe secret Id is: {wsId}");
//    await context.Response.WriteAsync($"\nThe secret Key is: {wsKey}");
//});
//app.MapGet("/", async context => 
//{ 
//    await context.Response.WriteAsync("Hello World!"); 
//});

app.MapGet("/cookie", async context =>
{
    //var counter1 = int.Parse(context.Request.Cookies["counter1"] ?? "0") + 1;
    //context.Response.Cookies.Append("counter1", counter1.ToString(), 
    //    new CookieOptions 
    //    { 
    //        MaxAge = TimeSpan.FromMinutes(30),
    //        IsEssential = true,
    //    });
    //var counter2 = int.Parse(context.Request.Cookies["counter2"] ?? "0") + 1;
    //context.Response.Cookies.Append("counter2", counter2.ToString(), 
    //    new CookieOptions 
    //    { 
    //        MaxAge = TimeSpan.FromMinutes(30) 
    //    });
    var counter1 = (context.Session.GetInt32("counter1") ?? 0) + 1;
    var counter2 = (context.Session.GetInt32("counter2") ?? 0) + 1;
    context.Session.SetInt32("counter1", counter1);
    context.Session.SetInt32("counter2", counter2);
    await context.Session.CommitAsync();
    await context.Response.WriteAsync($"Counter1: {counter1}, counter2: {counter2}");
});
app.MapGet("/clear", context =>
{
    //context.Response.Cookies.Delete("counter1");
    //context.Response.Cookies.Delete("counter2");
    context.Session.Clear();
    context.Response.Redirect("/");
    return Task.CompletedTask;
});

app.MapFallback(async context =>
{
    await context.Response.WriteAsync($"HTTPS Request: {context.Request.IsHttps}\n");
    await context.Response.WriteAsync("Hello World!");
});

app.Run();
