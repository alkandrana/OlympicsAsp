namespace OlympicsAsp.Models;

public class Goal
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public DateOnly StartDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);
    public DateOnly Deadline { get; set; }
}
