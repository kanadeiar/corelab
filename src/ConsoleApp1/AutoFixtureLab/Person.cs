namespace ConsoleApp1.AutoFixtureLab;

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string MiddleName { get; set; } = default!;
    public DateTime Birthday { get; set; }
    
    public IEnumerable<Address>? Addresses { get; set; }
    
    public IEnumerable<Pet>? Pets { get; set; }
    public Pet Current { get; set; }

    public Person()
    {
        Id = 1;
    }

    public int GetAge()
    {
        return DateTime.Today.Year - Birthday.Year;
    }
}


