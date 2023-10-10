using Application.ViewModel;
using MediatR;

namespace Application.Entities.Tasks.Queries.GetTaskById;

public class GetTaskByIdQuery : IRequest<ApiResponse<GetTasksDTO>>
{
    public int id { get; set; }
}