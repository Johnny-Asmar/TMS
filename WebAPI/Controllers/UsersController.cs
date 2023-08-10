using Application.Entities.Users.Queries.CreateUserToken;
using Application.Entities.Users.Queries.Login;
using Application.Entities.Users.Queries.Register;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;

[Route("[controller]")]
[ApiController]
public class UsersController : Controller
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("UserExist")]
    public async Task<string> CheckUserExist(UserExistQuery userExistQuery)
    {
        var result = await _mediator.Send(userExistQuery);
        return result;
    }
    
    [HttpPost("AddUser")]
    public async Task<string> AddUser([FromBody] AddUserCommand addUserCommand)
    {
        var result = await _mediator.Send(addUserCommand);
        return result;
    }
    
    [HttpPost("CreateUserToken")]
    public async Task<string> CreateUserToken([FromForm] CreateUserTokenQuery createUserTokenQuery)
    {
        var result = await _mediator.Send(createUserTokenQuery);
        return result;
    }

}