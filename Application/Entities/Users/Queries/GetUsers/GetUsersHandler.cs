using Application.Entities.Tasks.Queries.GetTasks;

using Domain.Models;
using MediatR;

namespace Application.Entities.Users.Queries.GetUsers;

public class GetUsersHandler : IRequestHandler<GetUsersQuery, List<User>>
{
    public postgresContext _postgresContext;
    private IRequestHandler<GetUsersQuery, List<User>> _requestHandlerImplementation;

    public GetUsersHandler(postgresContext postgresContext)
    {
        _postgresContext = postgresContext;
    }

    public async Task<List<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        // Get All Users
        List<User> listOfUsers =  _postgresContext.Users.ToList();
        return listOfUsers;
    }
}