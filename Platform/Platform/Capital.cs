namespace Platform;

public static class Capital
{
    public static async Task Endpoint(HttpContext context)
    {
        string? capital = null;
        string? country = context.Request.RouteValues["country"] as string;
        switch ((country ?? "").ToLower())
        {
            case "uk":
                capital = "London";
                break;
            case "russia":
                capital = "Moscow";
                break;
            case "france":
                capital = "Paris";
                break;
            case "monaco":
                LinkGenerator? generator =
                    context.RequestServices.GetService<LinkGenerator>();
                string? url = generator?.GetPathByRouteValues(context,
                    "population", new { city = country });
                context.Response.Redirect(url);
                return;
        }
        if (capital != null)
        {
            await context.Response.WriteAsync($"{capital} is the capital of {country}");
            return;
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
        }
    }
}

//public class Capital
//{
//    private RequestDelegate _next;
//    public Capital() { }
//    public Capital(RequestDelegate nextDelegate)
//    {
//        _next = nextDelegate;
//    }
//    public async Task Invoke(HttpContext context)
//    {
//        string[] parts = context.Request.Path.ToString().Split('/', StringSplitOptions.RemoveEmptyEntries);
//        if (parts.Length == 2 && parts[0] == "capital")
//        {
//            string country = parts[1];
//            string? capital = null;
//            switch (country.ToLower())
//            {
//                case "uk":
//                    capital = "London";
//                    break;
//                case "russia":
//                    capital = "moscow";
//                    break;
//                case "france":
//                    capital = "paris";
//                    break;
//                case "monaco":
//                    LinkGenerator? generator =
//                        context.RequestServices.GetService<LinkGenerator>();
//                    string? url = generator?.GetPathByRouteValues(context,
//                        "population", new { city = country });
//                    if (url != null)
//                    {
//                        context.Response.Redirect(url);
//                    }
//                    break;
//            }
//            if (capital != null)
//            {
//                await context.Response.WriteAsync($"{capital} is the capital of {country}");
//                return;
//            }
//        }
//        if (_next != null)
//            await _next(context);
//    }
//}
