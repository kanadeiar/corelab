using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SimpleConsole;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        var connectionstring = @"server=.,5433;Database=AutoLotSamples;
User Id=sa;Password=P@sswOrd";
        optionsBuilder.UseSqlServer(connectionstring);
        Console.WriteLine(connectionstring);
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}