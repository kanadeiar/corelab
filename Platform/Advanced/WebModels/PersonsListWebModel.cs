namespace Advanced.WebModels;

public class PersonsListWebModel
{
    public IEnumerable<Person> Persons { get; set; } = Enumerable.Empty<Person>();
    public IEnumerable<string> Cities { get; set; } = Enumerable.Empty<string>();
    public string SelectedCity { get; set; } = string.Empty;
    public string GetClass(string? city) => SelectedCity == city ? "bg-info" : string.Empty;
}
