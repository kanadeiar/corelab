using Microsoft.EntityFrameworkCore;
using SimpleConsole.Models;

namespace SimpleConsole;

public partial class ApplicationDbContext : DbContext
{
    public DbSet<Sample> Samples => Set<Sample>();
    public DbSet<Make> Makes => Set<Make>();
    public DbSet<Ratio> Ratios => Set<Ratio>();
    public DbSet<Driver> Drivers => Set<Driver>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sample>(x =>
        {
            x.ToTable("MySamples", "dbo");
            x.HasKey(x => x.Id);
            x.HasIndex(x => x.MakeId, "IX_Index_1");
            x.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasDefaultValue("Копейка");
            x.Property(x => x.TimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken();
            x.Property(x => x.IsTest)
                .HasField("_isTest")
                .HasDefaultValue(true);
            x.Property(x => x.IsTest)
                .IsSparse();
            x.Property(x => x.AdvancedName)
                .HasComputedColumnSql("Advanced [Name]", stored: true);

            x.HasOne(s => s.MakeNavigation)
                .WithMany(p => p.Samples)
                .HasForeignKey(s => s.MakeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sample_Make_MakeId");
        });
        modelBuilder.Entity<Make>()
            .HasCheckConstraint(name: "CH_Name", sql: "[Name]<>'Test'", buildAction: c => c.HasName("CK_Check_Name"));
        modelBuilder.Entity<BaseEntity>().ToTable("BaseEntities");

        modelBuilder.Entity<Ratio>(x =>
        {
            x.HasIndex(x => x.SampleId, "XII_Ratios_CarId")
                .IsUnique();
            x.HasOne(x => x.SampleNavigation)
                .WithOne(x => x.RatioNavigation)
                .HasForeignKey<Ratio>(x => x.SampleId);
        });

        modelBuilder.Entity<Sample>()
            .HasMany(x => x.Drivers)
            .WithMany(x => x.Samples)
            .UsingEntity<Dictionary<string, object>>(
                "SampleDriver",
                j => j.HasOne<Driver>()
                .WithMany()
                .HasForeignKey("DriverId")
                .OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne<Sample>()
                .WithMany()
                .HasForeignKey("SamleId")
                .OnDelete(DeleteBehavior.ClientCascade);
            );
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>().HaveMaxLength(100);
    }

}