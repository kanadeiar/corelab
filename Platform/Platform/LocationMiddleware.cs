namespace Platform;

public class LocationMiddleware
{
    private RequestDelegate next;
    private MessageOptions options;
    private readonly ILogger<LocationMiddleware> _logger;
    public LocationMiddleware(RequestDelegate nextDelegate,
            IOptions<MessageOptions> opts, ILogger<LocationMiddleware> logger)
    {
        next = nextDelegate;
        options = opts.Value;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Path == "/location")
        {
            _logger.LogDebug($"Response for started, path = {context.Request.Path}");
            await context.Response
                .WriteAsync($"{options.CityName}, {options.CountryName}");
        }
        else
        {
            await next(context);
        }
    }
}
