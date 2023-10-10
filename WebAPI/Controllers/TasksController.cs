using Application;
using Application.Entities.Tasks.Commands.AddTask;
using Application.Entities.Tasks.Commands.DeleteTask;
using Application.Entities.Tasks.Commands.UpdateTask;
using Application.Entities.Tasks.Queries.GetTaskById;
using Application.Entities.Tasks.Queries.GetTasks;
using Application.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task = Domain.Models.Task;


namespace WebApi.Controllers;
[Route("[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly IMediator _mediator;

    public TasksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("AddTask")]
    public async Task<ApiResponse<string>> AddTask([FromBody] AddTaskCommand addTaskCommand)
    {

        var task = await _mediator.Send(addTaskCommand);

        return task;

    }

    [HttpDelete("DeleteTask/{id:int}")]
    public async Task<ApiResponse<string>> DeleteTask([FromRoute] int id)
    {
        return await _mediator.Send(new DeleteTaskCommand()
        {
            id = id
        });
    }

    [HttpPost("UpdateTask")]
    public async Task<ApiResponse<string>> UpdateUser([FromBody] UpdateTaskCommand updateTaskCommand)
    {
        var task = await _mediator.Send(updateTaskCommand);
        return task;
    }

    [HttpGet("GetTaskById/{id:int}")]
    public async Task<ApiResponse<GetTasksDTO>> GetTaskById([FromRoute] int id)
    {
        return await _mediator.Send(new GetTaskByIdQuery()
        {
            id = id
        });
    }

    [HttpGet("GetAllTasksWithUserName")]
    public async Task<ApiResponse<List<GetTasksWithUserNameDTO>>> GetAllTasksWithUserName([FromRoute]GetAllTasksWithUserNameQuery getTasksQuery)
    {
        var listOfTasks =  await _mediator.Send(getTasksQuery);
        return listOfTasks;
    }
}