namespace Platform;

public class CountryRouteConstraint : IRouteConstraint
{
    private static string[] _countries = { "uk", "russia", "france", "monaco" };
    public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    {
        string segmentValue = values[routeKey] as string ?? "";
        return Array.IndexOf(_countries, segmentValue.ToLower()) >= 0;
    }
}
