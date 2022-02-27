var builder = WebApplication.CreateBuilder(args);

var servicesConfig = builder.Configuration;
var servicesEnv = builder.Environment;

builder.Services.Configure<MessageOptions>(servicesConfig.GetSection("Location"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.Logger.LogDebug("Start program pipeline");
}

var pipelineConfig = app.Configuration;
var pipelineEnv = app.Environment;

app.UseMiddleware<LocationMiddleware>();

app.MapGet("config", async (HttpContext context, IConfiguration config, IWebHostEnvironment env) =>
{
    var defDebug = pipelineConfig["Logging:LogLevel:Default"];
    await context.Response.WriteAsync($"The config settings is {defDebug}\n");
    string environ = config["ASPNETCORE_ENVIRONMENT"];
    await context.Response.WriteAsync($"The env settings is: {environ}\n");
    await context.Response.WriteAsync($"The env is {env.EnvironmentName}\n");
    var wsId = config["WebService:Id"];
    var wsKey = config["WebService:Key"];
    await context.Response.WriteAsync($"\nThe secret Id is: {wsId}");
    await context.Response.WriteAsync($"\nThe secret Key is: {wsKey}");
});

app.MapGet("/", async context => 
{ 
    await context.Response.WriteAsync("Hello World!"); 
});

app.Run();
