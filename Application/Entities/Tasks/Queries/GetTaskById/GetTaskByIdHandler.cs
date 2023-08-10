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
        var Fetchedtask = _postgresContext.Tasks.FirstOrDefault(t => t.Id == request.id);
        if (Fetchedtask != null)
        {
            return Fetchedtask;
        }
        else
        {
            throw new Exception("Does not exist");
        }

    }
}