using MediatR;

namespace Application.Entities.Tasks.Commands.DeleteTask;

public class DeleteTaskCommand : IRequest<string>
{
    public int id { get; set; }
}