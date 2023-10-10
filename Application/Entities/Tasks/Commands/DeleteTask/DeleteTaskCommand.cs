using MediatR;

namespace Application.Entities.Tasks.Commands.DeleteTask;

public class DeleteTaskCommand : IRequest<ApiResponse<string>>
{
    public int id { get; set; }
}