using Advanced.Data;
using Advanced.WebModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Advanced.Controllers;

public class HomeController : Controller
{
    private readonly DataContext _dataContext;
    public HomeController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public IActionResult Index([FromQuery] string selectedCity)
    {
        var model = new PersonsListWebModel
        {
            Persons = _dataContext.Persons.Include(_ => _.Department).Include(_ => _.Location).AsNoTracking(),
            Cities = _dataContext.Locations.Select(_ => _.City).Distinct(),
            SelectedCity = selectedCity,
        };
        return View(model);
    }
}
