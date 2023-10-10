using MediatR;
namespace Application.Entities.Tasks.Commands.AddTask;

public class AddTaskCommand : IRequest<ApiResponse<string>>
{
    
    public string title { get; set; }
    public string description { get; set; }
    public int userId { get; set; }
    public DateTime endDate { get; set; }
    public string status { get; set; }

    

}