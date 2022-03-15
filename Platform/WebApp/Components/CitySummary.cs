using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Components;

[ViewComponent]
public class CitySummary : ViewComponent
{
    private readonly CitiesData _cities;
    public CitySummary(CitiesData cities)
    {
        _cities = cities;
    }
    public string Invoke()
    {
        var result = $"{_cities.Cities.Count()} cities, {_cities.Cities.Sum(x => x.Population)} people";
        return result;
    }
}
