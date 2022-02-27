namespace Platform.Services;

public class TimeResponseFormatter : IResponseFormatter
{
    private ITimeStamper _stamper;
    public TimeResponseFormatter(ITimeStamper timeStamper)
    {
        _stamper = timeStamper;
    }
    public async Task Format(HttpContext context, string content)
    {
        await context.Response.WriteAsync($"{_stamper.TimeStamp}: {content}");
    }
}
