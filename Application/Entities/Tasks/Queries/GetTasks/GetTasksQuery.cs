using Application.ViewModel;
using MediatR;

namespace Application.Entities.Tasks.Queries.GetTasks;

public class GetTasksQuery : IRequest<List<GetTasksDTO>>
{
    
}