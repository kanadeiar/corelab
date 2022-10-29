using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SimpleConsole.ViewModels.Configuration;

namespace SimpleConsole.ViewModels;

[Keyless]
[EntityTypeConfiguration(typeof(SampleViewModelConfiguration))]
public class SampleViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    [NotMapped]
    public string FullDetail => $"The {Name}";
    public override string ToString() => FullDetail;
}