using Application.Repositories.Abstraction;
using Application.ViewModel;
using MediatR;

namespace Application.Entities.Tasks.Queries.GetTaskById;

public class GetTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, ApiResponse<GetTasksDTO>>
{
    public ITaskRepository _taskRepository;
    
    public GetTaskByIdHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<ApiResponse<GetTasksDTO>> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        return _taskRepository.GetTaskDTOById(request.id);
    }
}