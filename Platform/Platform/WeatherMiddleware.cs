namespace Platform;

public class WeatherMiddleware
{
    private RequestDelegate _next;
    public WeatherMiddleware(RequestDelegate nextDelegate)
    {
        _next = nextDelegate;
    }
    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Path == "/middleware/class")
        {
            await context.Response.WriteAsync("Middleware class: It is first sample");
        }
        else
            await _next(context);
    }
}
