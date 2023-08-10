using MediatR;

namespace Application.Entities.Tasks.Commands.UpdateTask;

public class UpdateTaskCommand : IRequest<string>
{
    public int id { get; set; }
    public int priority { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public int UserId { get; set; }
    public DateTime endDate { get; set; }
    public string status { get; set; }
    

}