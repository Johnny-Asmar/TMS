using MediatR;

namespace Application.Entities.Users.Queries.Login;

public class UserExistQuery : IRequest<string>
{
    public string username { get; set; }
    public string password { get; set; }
}