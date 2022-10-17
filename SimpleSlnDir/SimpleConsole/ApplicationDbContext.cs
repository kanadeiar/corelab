using Microsoft.EntityFrameworkCore;
using SimpleConsole.Models;
using SimpleConsole.ViewModels;
using SimpleConsole.ViewModels.Configuration;

namespace SimpleConsole;

public partial class ApplicationDbContext : DbContext
{
    [DbFunction("test_SamplesCountFor", Schema = "dbo")]
    public static int SamplesCountFor(int makeId) => throw new NotSupportedException();

    [DbFunction("test_GetSamplesForMake", Schema = "dbo")]
    public IQueryable<Sample> GetSamplesFor(int makeId) => FromExpression(() => GetSamplesFor(makeId));

    public DbSet<Sample> Samples => Set<Sample>();
    public DbSet<Make> Makes => Set<Make>();
    public DbSet<Ratio> Ratios => Set<Ratio>();
    public DbSet<Driver> Drivers => Set<Driver>();
    public DbSet<SampleDriver> SampleDrivers => Set<SampleDriver>();

    public DbSet<SampleViewModel> SampleViewModels => Set<SampleViewModel>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Driver>(x =>
        {
            x.OwnsOne(o => o.PersonInfo, pd =>
            {
                pd.Property<string>(nameof(Person.FirstName))
                    .HasColumnName(nameof(Person.FirstName))
                    .HasColumnType("nvarchar(50)");
                pd.Property<string>(nameof(Person.LastName))
                    .HasColumnName(nameof(Person.LastName))
                    .HasColumnName("nvarchar(50)");
            });
            x.Navigation(d => d.PersonInfo).IsRequired(true);
        });

        new SampleConfiguration().Configure(modelBuilder.Entity<Sample>());
        new SampleViewModelConfiguration().Configure(modelBuilder.Entity<SampleViewModel>());

        modelBuilder.Entity<Make>()
            .HasCheckConstraint(name: "CH_Name", sql: "[Name]<>'Test'", buildAction: c => c.HasName("CK_Check_Name"));
        modelBuilder.Entity<BaseEntity>()
            .ToTable("BaseEntities", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<Ratio>(x =>
        {
            x.HasIndex(x => x.SampleId, "XII_Ratios_CarId")
                .IsUnique();
            x.HasOne(x => x.SampleNavigation)
                .WithOne(x => x.RatioNavigation)
                .HasForeignKey<Ratio>(x => x.SampleId);
        });
        modelBuilder.Entity<Ratio>().HasQueryFilter(e =>
            e.SampleNavigation.IsTest);
        modelBuilder.Entity<SampleViewModel>()
            .ToTable("Samples")
            .ToView("SampleWithMakeView");
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>().HaveMaxLength(100);
    }

}