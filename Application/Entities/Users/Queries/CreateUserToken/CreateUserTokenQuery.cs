using MediatR;

namespace Application.Entities.Users.Queries.CreateUserToken;

public class CreateUserTokenQuery : IRequest<string>
{
    public string username { get; set; }
    public int roleId { get; set; }

}