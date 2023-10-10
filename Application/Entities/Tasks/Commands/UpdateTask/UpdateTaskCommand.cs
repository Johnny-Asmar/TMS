using MediatR;

namespace Application.Entities.Tasks.Commands.UpdateTask;

public class UpdateTaskCommand : IRequest<ApiResponse<string>>
{
    public int id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public int userId { get; set; }
    public DateTime endDate { get; set; }
    public string status { get; set; }
    

}