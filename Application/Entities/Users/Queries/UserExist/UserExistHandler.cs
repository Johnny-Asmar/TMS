using Application.Entities.Tasks.Queries.GetTaskById;
using Domain.Models;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Application.Entities.Users.Queries.Login;

public class UserExistHandler : IRequestHandler<UserExistQuery, int>
{
    public postgresContext _postgresContext;
    
    public UserExistHandler(postgresContext postgresContext)
    {
        _postgresContext = postgresContext;
    }

    public async Task<int> Handle(UserExistQuery request, CancellationToken cancellationToken)
    {
        var FetchedUser = _postgresContext.Users.FirstOrDefault(t => t.username == request.username && t.password == request.password);
        if (FetchedUser != null)
        {
            return FetchedUser.RoleId;
        }
        else
        {
            return 0;
        }

    }

}