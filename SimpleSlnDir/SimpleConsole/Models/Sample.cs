using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SimpleConsole.Models;

[Table("MySample", Schema = "dbo")]
[Index(nameof(MakeId), Name = "IX_MySample_MakeId")]
[EntityTypeConfiguration(typeof(SampleConfiguration))]
public class Sample : BaseEntity
{
    [Required, StringLength(40)]
    public string Name { get; set; }
    public int MakeId { get; set; }
    [ForeignKey(nameof(MakeId))]
    public Make MakeNavigation { get; set; }
    public Ratio RatioNavigation { get; set; }
    [InverseProperty(nameof(Driver.Samples))]
    public IEnumerable<Driver> Drivers { get; set; } = new List<Driver>();

    private bool? _isTest;
    public bool IsTest
    {
        get => _isTest ?? true;
        set => _isTest = value;
    }

    public string AdvancedName { get; set; }

    [InverseProperty(nameof(SampleDriver.SampleNavigation))]
    public IEnumerable<SampleDriver> SampleDrivers { get; set; } = new List<SampleDriver>();
}