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
        var task = _postgresContext.Tasks.FirstOrDefault(t => t.Id == request.id);
        if (task != null)
        {
            _postgresContext.Tasks.Remove(task);
            _postgresContext.SaveChanges();
            return "done";
        }
        else
        {
            throw new Exception("Does not exist");
        }

    }
    
}