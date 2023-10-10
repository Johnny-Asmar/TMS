using Application.Entities.Tasks.Queries.GetTaskById;
using Application.Repositories.Abstraction;
using Application.ViewModel;
using MediatR;
using Persistence.DB;
using System.Collections.Generic;
using Task = Domain.Models.Task;

namespace Application.Entities.Tasks.Queries.GetTasks;

public class GetAllTasksWithUserNameHandler : IRequestHandler<GetAllTasksWithUserNameQuery, ApiResponse<List<GetTasksWithUserNameDTO>>>
{
    public ITaskRepository _taskRepository;

    public GetAllTasksWithUserNameHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<ApiResponse<List<GetTasksWithUserNameDTO>>> Handle(GetAllTasksWithUserNameQuery request, CancellationToken cancellationToken)
    {
        return _taskRepository.GetTasksWithUserName();
    }
}