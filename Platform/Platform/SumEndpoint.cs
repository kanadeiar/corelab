using Microsoft.Extensions.Caching.Distributed;

namespace Platform;

public static class SumEndpoint
{
    public static async Task Endpoint(HttpContext context, IDistributedCache cache)
    {
        var count = int.Parse((string)context.Request.RouteValues["count"]);
        var cacheKey = $"sum_{count}";
        var totalStr = await cache.GetStringAsync(cacheKey);
        if (totalStr == null)
        {
            var total = 0L;
            for (int i = 0; i < count; i++)
            {
                total += i;
            }
            totalStr = $"({DateTime.Now.ToString("dd.MM.yyyy HH:mm")}) {total}";
            await cache.SetStringAsync(cacheKey, totalStr,
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
                });
        }

        await context.Response.WriteAsync($"({DateTime.Now.ToString("dd.MM.yyyy HH:mm")}) Total: {count}" + $" values:\n{totalStr}\n");
    }
}
