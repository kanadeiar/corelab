using Advanced.Data;
using Advanced.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Advanced.Handlers;

public class GetAllLocations : IRequest<IEnumerable<Location>>
{
}

public class GetAllLocationsHandler : IRequestHandler<GetAllLocations, IEnumerable<Location>>
{
    private readonly IUnitOfWork _work;
    public GetAllLocationsHandler(IUnitOfWork work)
    {
        _work = work;
    }
    public async Task<IEnumerable<Location>> Handle(GetAllLocations request, CancellationToken cancellationToken)
    {
        var locations = await _work.Locations.ToArrayAsync();
        return locations;
    }
}
