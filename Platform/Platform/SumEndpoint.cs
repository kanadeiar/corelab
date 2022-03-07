using Microsoft.Extensions.Caching.Distributed;

namespace Platform;

public static class SumEndpoint
{
    public static async Task Endpoint(HttpContext context, IDistributedCache cache, IResponseFormatter formatter, LinkGenerator generator, CalculationContext dataContext)
    {
        var count = int.Parse((string)context.Request.RouteValues["count"]);
        
        var cacheKey = $"sum_{count}";
        var totalStr = await cache.GetStringAsync(cacheKey);
        if (totalStr == null)
        {
            var total = dataContext.Calculations.FirstOrDefault(c => c.Count == count)?.Result ?? 0;
            if (total == 0)
            {
                for (int i = 0; i < count; i++)
                {
                    total += i;
                }
                dataContext.Calculations.Add(new Calculation { Count = count, Result = total });
                await dataContext.SaveChangesAsync();
            }
            totalStr = $"({DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}) {total}";
            await cache.SetStringAsync(cacheKey, totalStr, 
                new DistributedCacheEntryOptions 
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1) 
                });
        }

        ////var total = 0L;
        //if (total == 0)
        //{
        //    for (int i = 0; i < count; i++)
        //    {
        //        total += i;
        //    }
        //    dataContext.Calculations.Add(new Calculation { Count = count, Result = total });
        //    await dataContext.SaveChangesAsync();
        //}
        //var totalStr = $"({DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}) {total}";
            //context.Response.Headers["Cache-Control"] = "public, max-age=120";
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
