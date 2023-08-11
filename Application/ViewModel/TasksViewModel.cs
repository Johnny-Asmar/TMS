namespace Application.ViewModel;

public class TasksViewModel
{
    public int Priority { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int AssignedTo { get; set; }
    public DateTime endDate { get; set; }
    public string status { get; set; }
}