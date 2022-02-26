using Platform;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MiddlewareOptions>(options =>
{
    options.CityName = "Albany";
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseMiddleware<LocationMiddleware>();

app.Map("/branch", branch =>
{
    branch.Run(new QueryStringMiddleWare().Invoke);
});

app.Map("/time", appBuilder =>
{
    var time = DateTime.Now.ToShortTimeString();

    appBuilder.Use(async (context, next) =>
    {
        Console.WriteLine($"Time: {time}");
        await next();   
    });

    appBuilder.Run(async context => await context.Response.WriteAsync($"Time: {time}"));
});

app.Use(async (context, next) => {
    await next();
    await context.Response.WriteAsync($"\nCode: {context.Response.StatusCode}");
});
app.Use(async (context, next) => {
    if (context.Request.Path == "/short")
    {
        await context.Response.WriteAsync("Short circuited");
    }
    else
        await next();
});

app.UseMiddleware<QueryStringMiddleWare>();

app.MapGet("/", () => "Hello World!");

app.Run();
