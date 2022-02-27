var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddScoped<IResponseFormatter>(provider =>
//{
//    var typeName = builder.Configuration["services:IResponseFormatter"];
//    return (IResponseFormatter)ActivatorUtilities
//        .CreateInstance(provider, typeName == null 
//            ? typeof(GuidService) : Type.GetType(typeName, true)!);
//});
//builder.Services.AddScoped<ITimeStamper, DefaultTimeStamper>();
builder.Services.AddScoped<IResponseFormatter, TextResponseFormatter>();
builder.Services.AddScoped<IResponseFormatter, HtmlResponseFormatter>();
builder.Services.AddScoped<IResponseFormatter, GuidService>();

#region Old
//builder.Services.Configure<RouteOptions>(options =>
//{
//    options.ConstraintMap.Add("countryName", typeof(CountryRouteConstraint));
//});
#endregion

var app = builder.Build();

app.MapGet("single", async context =>
{
    IResponseFormatter formatter = context.RequestServices
        .GetRequiredService<IResponseFormatter>();
    await formatter.Format(context, "Single service");
});

app.MapGet("/", async context =>
{
    IResponseFormatter formatter = context.RequestServices
        .GetServices<IResponseFormatter>().First(x => x.RichOutput);
    await formatter.Format(context, "Multiple service");
});

//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//}

//app.UseRouting();

//app.UseMiddleware<WeatherMiddleware>();

////IResponseFormatter formatter = new TextResponseFormatter();
//app.MapGet("/middleware/function", async (HttpContext context, IResponseFormatter formatter) =>
//{
//    await formatter.Format(context, "Middleware Function: It is snowing in Chicago");
//});
////app.MapGet("/endpoint/class", WeatherEndpoint.Endpoint);
//app.MapEndpoint<WeatherEndpoint>("/endpoint/class");

//app.MapGet("/endpoint/function", async (HttpContext context, IResponseFormatter formatter) => {
//    await formatter.Format(context, "Endpoint function: is third sample");
//});

#region Old
//app.Use(async (context, next) =>
//{
//    var end = context.GetEndpoint();
//    if (end is { })
//    {
//        await context.Response.WriteAsync($"{end.DisplayName} Selected\n");
//    }
//    else
//        await context.Response.WriteAsync("No endpoint Selected\n");
//    await next(context);
//});
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapGet("{first:alpha}/{second:bool}/{*third}", async context =>
//    {
//        await context.Response.WriteAsync("Request Routed\n");
//        foreach (var item in context.Request.RouteValues)
//        {
//            await context.Response.WriteAsync($"{item.Key}: {item.Value}\n");
//        }
//    });
//    endpoints.MapGet("capital/{country:regex(^uk|russia|france|monaco$)}", Capital.Endpoint);
//    endpoints.MapGet("size/{city?}", Population.Enpoint)
//        .WithMetadata(new RouteNameMetadata("population"));
//});
//app.Map("{number:int}", async context =>
//{
//    await context.Response.WriteAsync("First endpoint");
//}).WithDisplayName("Int Endpoint")
//    .Add(b => ((RouteEndpointBuilder)b).Order = 1);
//app.Map("{number:double}", async context =>
//{
//    await context.Response.WriteAsync("Second endpoint");
//}).WithDisplayName("Double Endpoint")
//    .Add(b => ((RouteEndpointBuilder)b).Order = 2);
//app.Map("{first:alpha}/{second:bool}/{*third}", async context =>
//{
//    await context.Response.WriteAsync("Request Routed\n");
//    foreach (var item in context.Request.RouteValues)
//    {
//        await context.Response.WriteAsync($"{item.Key}: {item.Value}\n");
//    }
//});
////app.Map("capital/{country:regex(^uk|russia|france|monaco$)}", Capital.Endpoint);
//app.Map("capital/{country:countryName}", Capital.Endpoint);
//app.Map("size/{city?}", Population.Enpoint)
//    .WithMetadata(new RouteNameMetadata("population"));
//app.MapFallback(async context =>
//{
//    await context.Response.WriteAsync("Routed to fallback endpoint");
//});
#endregion

//app.MapGet("/", () => "Hello World!");

app.Run();
