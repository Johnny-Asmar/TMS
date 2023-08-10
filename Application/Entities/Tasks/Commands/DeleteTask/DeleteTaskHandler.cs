using Domain.Models;
namespace Application.Entities.Tasks.Commands.DeleteTask;
using MediatR;


public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, string>
{

    private postgresContext _postgresContext;
    
    public DeleteTaskHandler(postgresContext postgresContext)
    {
        _postgresContext = postgresContext;
    }
    public async Task<string> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        // Get Task By id
        var task = _postgresContext.Tasks.FirstOrDefault(t => t.Id == request.id);
        if (task != null)
        {
            // Task exists, delete it
            _postgresContext.Tasks.Remove(task);
            _postgresContext.SaveChanges();
            return "done";
        }
        else
        {
            // Task does not exist
            throw new Exception("Does not exist");
        }

    }
    
}