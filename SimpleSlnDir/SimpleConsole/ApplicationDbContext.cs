using Microsoft.EntityFrameworkCore;
using SimpleConsole.Models;

namespace SimpleConsole;

public partial class ApplicationDbContext : DbContext
{
    public DbSet<Sample> Samples { get; set; }

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
}