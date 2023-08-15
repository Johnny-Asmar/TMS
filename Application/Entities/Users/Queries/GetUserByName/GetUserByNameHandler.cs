using Application.Entities.Users.Queries.GetUsers;
using Domain.Models;
using MediatR;

namespace Application.Entities.Users.Queries.GetUserByName;

public class GetUserByNameHandler : IRequestHandler<GetUserByNameQuery, User>
{
    public postgresContext _postgresContext;
    private IRequestHandler<GetUsersQuery, List<User>> _requestHandlerImplementation;

    public GetUserByNameHandler(postgresContext postgresContext)
    {
        _postgresContext = postgresContext;
    }

    public async Task<User> Handle(GetUserByNameQuery request, CancellationToken cancellationToken)
    {
        // Get User by Name
        var FetchedUser = _postgresContext.Users.FirstOrDefault(u => u.Name == request.name);
        if (FetchedUser != null)
        {
            // If exists, get Task
            return FetchedUser;
        }
        else
        {
            // Task does not exist
            throw new Exception("Does not exist");
        }
    }

}