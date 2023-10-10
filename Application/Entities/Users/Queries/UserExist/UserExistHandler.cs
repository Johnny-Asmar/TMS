using Application.Entities.Tasks.Queries.GetTaskById;
using Domain.Models;
using MediatR;
using Persistence.DB;
using Task = System.Threading.Tasks.Task;

namespace Application.Entities.Users.Queries.Login;

public class UserExistHandler : IRequestHandler<UserExistQuery, int>
{
    public Context _postgresContext;
    
    public UserExistHandler(Context postgresContext)
    {
        _postgresContext = postgresContext;
    }

    public async Task<int> Handle(UserExistQuery request, CancellationToken cancellationToken)
    {
        var FetchedUser = _postgresContext.Users.ToList().FirstOrDefault(t => t.Username == request.username && t.Password == request.password, new User { Id=-1, Name = "NOT FOUND"});
        return FetchedUser.RoleId;
    }
}