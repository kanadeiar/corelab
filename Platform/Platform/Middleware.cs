using Microsoft.Extensions.Options;

namespace Platform;

public class QueryStringMiddleWare
{
    private RequestDelegate? next;

    public QueryStringMiddleWare()
    {
        // do nothing
    }

    public QueryStringMiddleWare(RequestDelegate nextDelegate)
    {
        next = nextDelegate;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Method == HttpMethods.Get
            )
        {
            if (!context.Response.HasStarted)
            {
                context.Response.ContentType = "text/plain";
            }
            await context.Response.WriteAsync("1 Class-based Middleware \n");
        }
        if (next != null)
        {
            await next(context);
        }
        await context.Response.WriteAsync("\n2 Class-based Middleware \n");
    }
}

public class LocationMiddleware
{
    private readonly RequestDelegate _nextDelegate;
    private readonly MiddlewareOptions _opts;
    public LocationMiddleware(RequestDelegate nextDelegate, IOptions<MiddlewareOptions> opts)
    {
        _nextDelegate = nextDelegate;
        _opts = opts.Value;
    }
    public async Task Invoke(HttpContext content)
    {
        if (content.Request.Path == "/location")
        {
            await content.Response.WriteAsync($"{_opts.CityName}, {_opts.CountryName}");
        }
        else
        {
            await _nextDelegate(content);
        }
    }
}