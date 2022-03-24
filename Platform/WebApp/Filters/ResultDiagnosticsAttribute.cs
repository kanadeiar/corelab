using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace WebApp.Filters;

public class ResultDiagnosticsAttribute : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        if (context.HttpContext.Request.Query.ContainsKey("diag"))
        {
            var diagData = new Dictionary<string, string?>
            {
                { "ResultType", context.Result.GetType().Name }
            };
            if (context.Result is ViewResult vr)
            {
                diagData["ViewData"] = vr.ViewName;
                diagData["ModelType"] = vr.ViewData?.Model?.GetType().Name;
                diagData["ModelData"] = vr.ViewData?.Model?.ToString();
            }
            else if (context.Result is PageResult pr)
            {
                diagData["ModelType"] = pr.Model?.GetType().Name;
                diagData["ModelData"] = pr.ViewData?.Model?.ToString();
            }
            context.Result = new ViewResult()
            {
                ViewName = "/Views/Shared/Message.cshtml",
                ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                {
                    Model = diagData
                }
            };
        }
        await next();
    }
}
