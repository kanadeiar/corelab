using Advanced.Data;
using Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Advanced;

public static class TestData
{
    public static void SeedTestData(DataContext context)
    {
        context.Database.Migrate();
        if (context.Persons.Any())
        {
            return;
        }
        var d1 = new Department { Name = "Администрация" };
        var d2 = new Department { Name = "Продажи" };
        var d3 = new Department { Name = "Разработка" };
        var d4 = new Department { Name = "Тестирование" };
        context.Departments.AddRange(d1, d2, d3, d4);
        context.SaveChanges();
        var l1 = new Location { State = "Московская область", City = "Москва" };
        var l2 = new Location { State = "Ленинградская область", City = "Ленинград" };
        var l3 = new Location { State = "Сталинградская область", City = "Сталинград" };
        context.Locations.AddRange(l1, l2, l3);
        context.SaveChanges();
        context.Persons.AddRange(
            new Person { SurName = "Иванов", FirstName = "Иван", Department = d1, Location = l1 },
            new Person { SurName = "Петров", FirstName = "Петр", Department = d1, Location = l2 },
            new Person { SurName = "Сидоров", FirstName = "Сидор", Department = d2, Location = l3 },
            new Person { SurName = "Степанов", FirstName = "Иван", Department = d2, Location = l1 },
            new Person { SurName = "Филькин", FirstName = "Петр", Department = d3, Location = l2 },
            new Person { SurName = "Галкин", FirstName = "Сидор", Department = d3, Location = l3 },
            new Person { SurName = "Кукумов", FirstName = "Иван", Department = d4, Location = l1 },
            new Person { SurName = "Авгеев", FirstName = "Петр", Department = d4, Location = l2 },
            new Person { SurName = "Явинов", FirstName = "Сидор", Department = d1, Location = l3 }
            );
        context.SaveChanges();
    }
}
