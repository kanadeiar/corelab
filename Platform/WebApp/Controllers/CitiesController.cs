using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using WebApp.Models;

namespace WebApp.Controllers;

[ViewComponent(Name = "CitiesControllerHybrid")]
public class CitiesController : Controller
{
    private readonly CitiesData _data;
    public CitiesController(CitiesData data)
    {
        _data = data;
    }
    public IActionResult Index()
    {
        return View(_data.Cities);
    }
    public IViewComponentResult Invoke()
    {
        var result = new ViewViewComponentResult()
        {
            ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CityWebModel>(
                ViewData,
                new CityWebModel
                {
                    Cities = _data.Cities.Count(),
                    Population = _data.Cities.Sum(x => x.Population),
                }),
        };
        return result;
    }
}
