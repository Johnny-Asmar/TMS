using Application.Entities.Users.Queries.CreateUserToken;
using Application.Entities.Users.Queries.GetUserByName;
using Application.Entities.Users.Queries.GetUsers;
using Application.Entities.Users.Queries.Login;
using Application.Entities.Users.Queries.Register;
using Domain.Models;
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
    public async Task<int> CheckUserExist(UserExistQuery userExistQuery)
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
    
    [HttpGet("GetUsers")]
    public async Task<List<User>> GetUsers([FromRoute]GetUsersQuery getUsersQuery)
    {
        Console.WriteLine("Controllerr");
        var listOfUsers =  await _mediator.Send(getUsersQuery);
        return listOfUsers;
    }
    [HttpGet("GetUserByName")]
    public async Task<User> GetUserByName([FromQuery] GetUserByNameQuery getUserByNameQuery)
    {
        var user =  await _mediator.Send(getUserByNameQuery);
        return user;
    }

}