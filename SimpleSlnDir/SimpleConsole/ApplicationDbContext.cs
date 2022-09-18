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
        modelBuilder.Entity<BaseEntity>().ToTable("BaseEntities");
        modelBuilder.Entity<Sample>().ToTable("Samples");
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>().HaveMaxLength(100);
    }
}