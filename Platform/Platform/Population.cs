namespace Platform;

public static class Population
{
    public static async Task Enpoint(HttpContext context)
    {
        int? pop = null;
        string? city = context.Request.RouteValues["city"] as string ?? "moscow";
        switch (city.ToLower())
        {
            case "london":
                pop = 8_332_323;
                break;
            case "moscow":
                pop = 4_432_435;
                break;
            case "paris":
                pop = 3_323_323;
                break;
            case "monaco":
                pop = 23_323;
                break;
        }
        if (pop.HasValue)
        {
            await context.Response
                .WriteAsync($"City: {city}, Population: {pop}");
            return;
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
        }
    }
}

//public class Population
//{
//    private RequestDelegate? _next;
//    public Population() { }
//    public Population(RequestDelegate nextDelegate)
//    {
//        _next = nextDelegate;
//    }
//    public async Task Invoke(HttpContext context)
//    {
//        string[] parts = context.Request.Path.ToString().Split('/', StringSplitOptions.RemoveEmptyEntries);
//        if (parts.Length == 2 && parts[0] == "population")
//        {
//            string city = parts[1];
//            int? pop = null;
//            switch (city.ToLower())
//            {
//                case "london":
//                    pop = 8_332_323;
//                    break;
//                case "moscow":
//                    pop = 4_432_435;
//                    break;
//                case "paris":
//                    pop = 3_323_323;
//                    break;
//                case "monaco":
//                    pop = 23_323;
//                    break;
//            }
//            if (pop.HasValue)
//            {
//                await context.Response
//                    .WriteAsync($"City: {city}, Population: {pop}");
//                return;
//            }
//        }
//        if (_next != null)
//            await _next(context);
//    }
//}
