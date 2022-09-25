using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SimpleConsole.ViewModels.Configuration;

namespace SimpleConsole.ViewModels;

[Keyless]
[EntityTypeConfiguration(typeof(SampleViewModelConfiguration))]
public class SampleViewModel
{
    public string Name { get; set; }
    [NotMapped]
    public string FullDetail => $"The {Name}";
    public override string ToString() => FullDetail;
}