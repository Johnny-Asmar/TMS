using MediatR;

namespace Application.Entities.Users.Queries.Register;

public class AddUserCommand : IRequest<string>
{
    public string username { get; set; }
    public string password { get; set; }
    public string name { get; set; }
}