using Advanced.Models;
using Microsoft.EntityFrameworkCore;

namespace Advanced.Data
{
    public interface IUnitOfWork
    {
        DbSet<Person> Persons { get; }
        DbSet<Location> Locations { get; }

        Task CommitAsync();
    }
}