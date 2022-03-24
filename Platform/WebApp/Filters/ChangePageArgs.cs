using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filters;

public class ChangePageArgs : Attribute, IPageFilter
{
    public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
    {        
    }

    public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
    {
        if (context.HandlerArguments.ContainsKey("message1"))
        {
            context.HandlerArguments["message1"] = "NewMessage1";
        }
    }

    public void OnPageHandlerSelected(PageHandlerSelectedContext context)
    {        
    }
}
