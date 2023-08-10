using Application.Entities.Tasks.Commands.AddTask;
using Application.Entities.Tasks.Commands.DeleteTask;
using Application.Entities.Tasks.Commands.UpdateTask;
using Application.Entities.Tasks.Queries.GetTaskById;
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
    public async Task<IActionResult> AddTask([FromBody] AddTaskCommand addTaskCommand)
    {

        var task = await _mediator.Send(addTaskCommand);

        return Ok(task);

    }

    [HttpDelete("DeleteTask/{id:int}")]
    public async Task<string> DeleteTask([FromRoute] int id)
    {
        return await _mediator.Send(new DeleteTaskCommand()
        {
            id = id
        });
    }

    [HttpPut("UpdateTask/{id:int}")]
    public async Task<string> UpdateUser([FromRoute] int id, [FromBody] UpdateTaskCommand updateTaskCommand)
    {
        updateTaskCommand.id = id;
        var task = await _mediator.Send(updateTaskCommand);

        return task;
    }
    
    [HttpGet("GetTaskById/{id:int}")]
    public async Task<Task> GetTaskById([FromRoute]int id)
    {
        return  await _mediator.Send(new GetTaskByIdQuery()
        {
            id = id
        });
        

    }

}