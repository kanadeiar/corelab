namespace Platform;

public class WeatherMiddleware
{
    private RequestDelegate _next;
    //private readonly IResponseFormatter _respFormatter;
    public WeatherMiddleware(RequestDelegate nextDelegate/*, IResponseFormatter respFormatter*/)
    {
        _next = nextDelegate;
        //_respFormatter = respFormatter;
    }
    public async Task Invoke(HttpContext context, IResponseFormatter formatter1, IResponseFormatter formatter2, IResponseFormatter formatter3)
    {
        if (context.Request.Path == "/middleware/class")
        {
            await formatter1.Format(context, "First\n");
            await formatter2.Format(context, "Second\n");
            await formatter3.Format(context, "Third\n");
        }
        else
            await _next(context);
    }
}
