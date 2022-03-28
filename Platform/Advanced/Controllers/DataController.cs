namespace Advanced.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DataController : ControllerBase
{
    private readonly DataContext _context;
    public DataController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Person> GetAll()
    {
        var people = _context.Persons.Include(x => x.Department).Include(x => x.Location);
        foreach (var p in people)
        {
            p.Department.Persons = default;
            p.Location.Persons = default;
            yield return p;
        }
    }

    [HttpGet("{id}")]
    public async Task<Person> Get(int id)
    {
        var p = await _context.Persons.Include(x => x.Department).Include(x => x.Location).FirstAsync(x => x.Id == id);
        p.Department.Persons = null;
        p.Location.Persons = null;
        return p;
    }

    [HttpPost]
    public async Task Add([FromBody] Person person)
    {
        await _context.Persons.AddAsync(person);
        await _context.SaveChangesAsync();
    }

    [HttpPut]
    public async Task Update([FromBody] Person person)
    {
        _context.Update(person);
        await _context.SaveChangesAsync();
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        _context.Persons.Remove(new Person() { Id = id });
        await _context.SaveChangesAsync();
    }

    [HttpGet("locations")]
    public IAsyncEnumerable<Location> GetLocations() => _context.Locations.AsAsyncEnumerable();

    [HttpGet("departments")]
    public IAsyncEnumerable<Department> GetDepartments() => _context.Departments.AsAsyncEnumerable();
}
