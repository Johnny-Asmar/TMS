using Application.Entities.Tasks.Queries.GetTaskById;
using Domain.Models;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Application.Entities.Users.Queries.Login;

public class UserExistHandler : IRequestHandler<UserExistQuery, string>
{
    public postgresContext _postgresContext;
    
    public UserExistHandler(postgresContext postgresContext)
    {
        _postgresContext = postgresContext;
    }

    public async Task<string> Handle(UserExistQuery request, CancellationToken cancellationToken)
    {
        var FetchedUser = _postgresContext.Users.FirstOrDefault(t => t.username == request.username && t.password == request.password);
        if (FetchedUser != null)
        {
            return "success";
        }
        else
        {
            throw new Exception("Does not exist");
        }

    }

}