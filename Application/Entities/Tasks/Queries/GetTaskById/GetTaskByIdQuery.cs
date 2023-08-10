using MediatR;
using Task = Domain.Models.Task;

namespace Application.Entities.Tasks.Queries.GetTaskById;

public class GetTaskByIdQuery : IRequest<Task>
{
    public int id { get; set; }
}