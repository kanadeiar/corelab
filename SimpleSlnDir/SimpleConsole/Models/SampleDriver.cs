using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleConsole.Models;

public class SampleDriver : BaseEntity
{
    public int SampleId { get; set; }
    [ForeignKey(nameof(SampleId))]
    public virtual Sample SampleNavigation { get; set; }

    public int DriverId { get; set; }
    [ForeignKey(nameof(DriverId))]
    public virtual Driver DriverNavigation { get; set; }
}