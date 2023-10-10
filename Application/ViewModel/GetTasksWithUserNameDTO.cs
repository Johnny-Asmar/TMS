namespace Application.ViewModel;

public class GetTasksWithUserNameDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime EndDate { get; set; }
    public string Status { get; set; }
    public string Name { get; set; }

}