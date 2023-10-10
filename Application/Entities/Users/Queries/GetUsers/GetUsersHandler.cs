using Application.Entities.Tasks.Queries.GetTasks;

using Domain.Models;
using MediatR;
using Persistence.DB;

namespace Application.Entities.Users.Queries.GetUsers;

public class GetUsersHandler : IRequestHandler<GetUsersQuery, List<User>>
{
    public Context _postgresContext;
    private IRequestHandler<GetUsersQuery, List<User>> _requestHandlerImplementation;

    public GetUsersHandler(Context postgresContext)
    {
        _postgresContext = postgresContext;
    }
    public async Task<List<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        Console.WriteLine("Handler");
        return _postgresContext.Users.ToList();
    }
}