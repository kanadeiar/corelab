using Advanced.Models;
using Microsoft.EntityFrameworkCore;

namespace Advanced.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;
    public UnitOfWork(DataContext context)
    {
        _context = context;
    }
    //public INinjaRepository Ninjas => new NinjaRepository(_context);
    public DbSet<Person> Persons => _context.Persons;
    public DbSet<Location> Locations => _context.Locations;

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}
