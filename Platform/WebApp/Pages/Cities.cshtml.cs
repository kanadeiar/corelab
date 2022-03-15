using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using WebApp.Models;

namespace WebApp.Pages;

[ViewComponent(Name = "CitiesPageHybrid")]
public class CitiesModel : PageModel
{
    public CitiesData Data { get; set; }
    public CitiesModel(CitiesData data)
    {
        Data = data;
    }
    [ViewComponentContext]
    public ViewComponentContext Context { get; set; }
    public IViewComponentResult Invoke()
    {
        var result = new ViewViewComponentResult
        {
            ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CityWebModel>(
                Context.ViewData,
                new CityWebModel {
                    Cities = Data.Cities.Count(),
                    Population = Data.Cities.Sum(x => x.Population),
                })
        };
        return result;
    }
}