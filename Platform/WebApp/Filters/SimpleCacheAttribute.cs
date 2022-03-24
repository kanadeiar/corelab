using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filters;

public class SimpleCacheAttribute : Attribute, IResourceFilter
{
    private Dictionary<PathString, IActionResult> _cachedResponses = new Dictionary<PathString, IActionResult>();
    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        var path = context.HttpContext.Request.Path;
        if (_cachedResponses.ContainsKey(path))
        {
            context.Result = _cachedResponses[path];
            _cachedResponses.Remove(path);
        }
    }

    public void OnResourceExecuted(ResourceExecutedContext context)
    {
        if (context != null)
        {
            _cachedResponses.Add(context.HttpContext.Request.Path, context.Result);
        }
    }
}
