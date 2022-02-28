namespace ConsoleAppGaF.Creational;

public class Person
{
    public string Name { get; set; }
    public Person ShallowCopy()
    {
        return (Person)MemberwiseClone();
    }
    public Person Copy()
    {
        var clone = (Person)MemberwiseClone();
        clone.Name = Name;
        return clone;
    }
}
