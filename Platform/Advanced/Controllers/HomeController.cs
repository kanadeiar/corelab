using Advanced.Data;
using Advanced.Handlers;
using Advanced.Models;
using Advanced.WebModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Advanced.Controllers;

public class HomeController : Controller
{
    private readonly IMediator _mediator;
    public HomeController(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<IActionResult> Index([FromQuery] string selectedCity)
    {
        var model = new PersonsListWebModel
        {
            Persons = await _mediator.Send(new GetAllPersons()),
            Cities = (await _mediator.Send(new GetAllLocations())).Select(_ => _.City).Distinct(),
            SelectedCity = selectedCity,
        };
        return View(model);
    }

    public async Task<IActionResult> Persons()
    {
        var person = new Person
        {
            SurName = "test",
            FirstName = "test",
            DepartmentId = 1,
            LocationId = 1,
        };
        var result = await _mediator.Send(new CreatePersonCommand(person));
        return View(result);
    }
}
