using Application.Entities.Users.Queries.GetUsers;
using Domain.Models;
using MediatR;
using Persistence.DB;

namespace Application.Entities.Users.Queries.GetUserByName;

public class GetUserByNameHandler : IRequestHandler<GetUserByNameQuery, User>
{
    public Context _postgresContext;
    private IRequestHandler<GetUsersQuery, List<User>> _requestHandlerImplementation;

    public GetUserByNameHandler(Context postgresContext)
    {
        _postgresContext = postgresContext;
    }
    public async Task<User> Handle(GetUserByNameQuery request, CancellationToken cancellationToken)
    {
        // Get User by Name
        var FetchedUser = _postgresContext.Users.ToList().FirstOrDefault(u => u.Name == request.name, new User
        {
            Id = -1,
            Name = "NOT FOUND"
        });
        // If exists, get Task
        return FetchedUser;
    }
}