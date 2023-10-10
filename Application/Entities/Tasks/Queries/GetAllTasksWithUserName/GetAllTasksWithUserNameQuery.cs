using Application.ViewModel;
using MediatR;

namespace Application.Entities.Tasks.Queries.GetTasks;

public class GetAllTasksWithUserNameQuery : IRequest<ApiResponse<List<GetTasksWithUserNameDTO>>>
{
    
}