using System.ComponentModel.DataAnnotations;

namespace OlympicsAsp.Models;

public class Session
{
    public int Id { get; set; }
    public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Today);
    public DateTime? StartTime { get; set; }
    public DateTime? StopTime { get; set; }

    [Required]
    public int Words { get; set; }

    [Required]
    public int GoalId { get; set; }
    public Goal? Goal { get; set; }
}
