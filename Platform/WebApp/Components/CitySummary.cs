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
    public IViewComponentResult Invoke(string themeName = "secondary")
    {
        ViewBag.Theme = themeName;
        var result = new CityWebModel
        {
            Cities = _cities.Cities.Count(),
            Population = _cities.Cities.Sum(x => x.Population),
        };
        return View(result);
    }
}
