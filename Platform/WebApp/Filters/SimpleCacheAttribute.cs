using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filters;

public class SimpleCacheAttribute : Attribute, IAsyncResourceFilter
{
    private Dictionary<PathString, IActionResult> _cachedResponses = new Dictionary<PathString, IActionResult>();
    public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
    {
        var path = context.HttpContext.Request.Path;
        if (_cachedResponses.ContainsKey(path))
        {
            context.Result = _cachedResponses[path];
            _cachedResponses.Remove(path);
        }
        else
        {
            var execContext = await next();
            if (execContext.Result != null)
            {
                _cachedResponses.Add(context.HttpContext.Request.Path, execContext.Result);
            }
        }
    }
}
