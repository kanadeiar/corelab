using Advanced.Data;
using Advanced.Models;
using MediatR;

namespace Advanced.Handlers;

public class CreatePersonCommand : IRequest<int>
{
    public Person Person { get; set; }
    public CreatePersonCommand(Person person)
    {
        Person = person;
    }
}

public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, int>
{
    private readonly IUnitOfWork _work;
    public CreatePersonCommandHandler(IUnitOfWork work)
    {
        _work = work;
    }
    public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        var model = request.Person;
        var entity = new Person
        {
            SurName = model.SurName,
            FirstName = model.FirstName,
            DepartmentId = model.DepartmentId,
            LocationId = model.LocationId,
        };
        _work.Persons.Add(entity);
        await _work.CommitAsync();
        return entity.Id;
    }
}
