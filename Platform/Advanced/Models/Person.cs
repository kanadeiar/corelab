namespace Advanced.Models;

public class Person
{
    public int Id { get; set; }
    public string SurName { get; set; }
    public string FirstName { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
    public int LocationId { get; set; }
    public Location Location { get; set; }
}
