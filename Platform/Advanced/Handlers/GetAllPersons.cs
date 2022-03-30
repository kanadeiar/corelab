using Advanced.Data;
using Advanced.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Advanced.Handlers;

public class GetAllPersons : IRequest<IEnumerable<Person>>
{
}

public class GetAllPersonsHandler : IRequestHandler<GetAllPersons, IEnumerable<Person>>
{
    private readonly IUnitOfWork _work;
    public GetAllPersonsHandler(IUnitOfWork work)
    {
        _work = work;
    }
    public async Task<IEnumerable<Person>> Handle(GetAllPersons request, CancellationToken cancellationToken)
    {
        var persons = await _work.Persons.Include(_ => _.Department).Include(_ => _.Location).AsNoTracking().ToArrayAsync();
        return persons;
    }
}
