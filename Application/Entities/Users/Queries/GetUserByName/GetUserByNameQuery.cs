using Domain.Models;
using MediatR;

namespace Application.Entities.Users.Queries.GetUserByName;

public class GetUserByNameQuery : IRequest<User>
{
    public string name { get; set; }
}
    
