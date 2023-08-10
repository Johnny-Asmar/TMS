using Domain.Models;
using MediatR;
using Task = Domain.Models.Task;

namespace Application.Entities.Tasks.Queries.GetTaskById;


public class GetTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, Task>
{
    public postgresContext _postgresContext;
    
    public GetTaskByIdHandler(postgresContext postgresContext)
    {
        _postgresContext = postgresContext;
    }

    public async Task<Task> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        // Get Task By id
        var Fetchedtask = _postgresContext.Tasks.FirstOrDefault(t => t.Id == request.id);
        if (Fetchedtask != null)
        {
            // If exists, get Task
            return Fetchedtask;
        }
        else
        {
            // Task does not exist
            throw new Exception("Does not exist");
        }

    }
}