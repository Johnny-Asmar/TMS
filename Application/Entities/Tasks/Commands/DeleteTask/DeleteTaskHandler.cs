namespace Application.Entities.Tasks.Commands.DeleteTask;

using Application.Repositories.Abstraction;
using MediatR;
using Persistence.DB;

public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, ApiResponse<string>>
{

    private ITaskRepository _taskRepository;
    
    public DeleteTaskHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }
    public async Task<ApiResponse<string>> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        return _taskRepository.DeleteTask(request.id);
    }
    
}