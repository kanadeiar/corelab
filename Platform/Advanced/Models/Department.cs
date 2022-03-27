namespace Advanced.Models;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<Person> Persons { get; set; } 
}
