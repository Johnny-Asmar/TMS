using Domain.Models;
using MediatR;

namespace Application.Entities.Users.Queries.GetUsers;

public class GetUsersQuery : IRequest<List<User>>
{
    
}