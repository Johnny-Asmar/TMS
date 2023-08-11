using Application.ViewModel;
using MediatR;

namespace Application.Entities.Tasks.Queries.GetTaskById;

public class GetTaskByIdQuery : IRequest<TasksViewModel>
{
    public int id { get; set; }
}