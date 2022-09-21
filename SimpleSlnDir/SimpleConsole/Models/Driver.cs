using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleConsole.Models;

public class Driver : BaseEntity
{
    public Person PersonInfo { get; set; } = new Person();
    public IEnumerable<Sample> Samples { get; set; } = new List<Sample>();

    [InverseProperty(nameof(SampleDriver.SampleNavigation))]
    public IEnumerable<SampleDriver> SampleDrivers { get; set; } = new List<SampleDriver>();
}