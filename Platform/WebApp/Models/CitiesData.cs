namespace WebApp.Models;

public class CitiesData
{
    private IList<City> _cities = new List<City>
    {
        new City { Name = "London", Country = "UK", Population = 800000 },
        new City { Name = "Moscow", Country = "Russia", Population = 900000 },
    };
    public IEnumerable<City> Cities => _cities;
    public void AddCity(City newCity)
    {
        _cities.Add(newCity);
    }
}
