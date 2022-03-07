using Microsoft.Extensions.Caching.Distributed;

namespace Platform;

public static class SumEndpoint
{
    public static async Task Endpoint(HttpContext context, IDistributedCache cache, IResponseFormatter formatter, LinkGenerator generator)
    {
        var count = int.Parse((string)context.Request.RouteValues["count"]);
        //var cacheKey = $"sum_{count}";
        //var totalStr = await cache.GetStringAsync(cacheKey);
        //if (totalStr == null)
        //{
            var total = 0L;
            for (int i = 0; i < count; i++)
            {
                total += i;
            }
            var totalStr = $"({DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}) {total}";
            context.Response.Headers["Cache-Control"] = "public, max-age=120";
            var url = generator.GetPathByRouteValues(context, null, new { count = count });
        //await cache.SetStringAsync(cacheKey, totalStr,
        //    new DistributedCacheEntryOptions
        //    {
        //        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
        //    });
        //}
        await formatter.Format(context, $"<div>({DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}) Total for {count} values:</div><div>{totalStr}</div><a href={url}>Reload</a>");
        //await context.Response.WriteAsync($"({DateTime.Now.ToString("dd.MM.yyyy HH:mm")}) Total: {count}" + $" values:\n{totalStr}\n");
    }
}
