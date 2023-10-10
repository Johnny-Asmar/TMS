namespace Application.ViewModel;

public class GetTasksDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int AssignedTo { get; set; }
    public DateTime EndDate { get; set; }
    public string Status { get; set; }
}