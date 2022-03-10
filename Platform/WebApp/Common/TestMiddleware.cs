using WebApp.Data;

namespace WebApp.Common;

public class TestMiddleware
{
    private readonly RequestDelegate next;
    public TestMiddleware(RequestDelegate next)
    {
        this.next = next;
    }
    public async Task Invoke(HttpContext context, DataContext data)
    {
        if (context.Request.Path == "/test")
        {
            await context.Response.WriteAsync($"There are {data.Products.Count()} products\n");
            await context.Response.WriteAsync($"There are {data.Categiries.Count()} categories\n");
            await context.Response.WriteAsync($"There are {data.Suppliers.Count()} suppliers\n");
        }
        else
        {
            await next(context);
        }
    }
}
