namespace ConsoleApp1.DDD;

public class Person(
    PersonId id, 
    PersonName name,
    PhoneNumber landline,
    PhoneNumber mobile,
    EmailAddress email,
    Height height,
    CountryCode country
    ) 
{
    private PersonId _id = id;
    private PersonName _name = name;
    private PhoneNumber _landline = landline;
    private PhoneNumber _mobile = mobile;
    private EmailAddress _email = email;
    private Height _height = height;
    private CountryCode _country = country;

}


public record PersonId(int Id);

public record PersonName(string SurName, string Name);