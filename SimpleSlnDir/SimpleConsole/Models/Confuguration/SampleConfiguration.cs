using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimpleConsole.Models.Confuguration;

public class SampleConfiguration : IEntityTypeConfiguration<Sample>
{
    public void Configure(EntityTypeBuilder<Sample> builder)
    {
        builder.ToTable(x => x.IsTemporal(t =>
        {
            t.HasPeriodEnd("ValidTo");
            t.HasPeriodStart("ValidFrom");
            t.UseHistoryTable("SampleHistory", "audits");
        }));

        builder.HasQueryFilter(x => x.IsTest == true);


        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.MakeId, "IX_Index_1");
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50)
            .HasDefaultValue("Копейка");
        builder.Property(x => x.TimeStamp)
            .IsRowVersion()
            .IsConcurrencyToken();
        builder.Property(x => x.IsTest)
            .HasField("_isTest")
            .HasDefaultValue(true);
        builder.Property(x => x.IsTest)
            .IsSparse();
        builder.Property(x => x.AdvancedName)
            .HasComputedColumnSql("Advanced [Name]", stored: true);
        builder.HasOne(s => s.MakeNavigation)
            .WithMany(p => p.Samples)
            .HasForeignKey(s => s.MakeId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Sample_Make_MakeId");
        builder
            .HasMany(x => x.Drivers)
            .WithMany(x => x.Samples)
            .UsingEntity<SampleDriver>(
                j => j.HasOne(x => x.DriverNavigation)
                     .WithMany(d => d.SampleDrivers)
                     .HasForeignKey(nameof(SampleDriver.DriverId))
                     .OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne(x => x.SampleNavigation)
                     .WithMany(d => d.SampleDrivers)
                     .HasForeignKey(nameof(SampleDriver.SampleId))
                     .OnDelete(DeleteBehavior.ClientCascade),
                j =>
                {
                    j.HasKey(x => new { x.SampleId, x.DriverId });
                }
            );

    }
}