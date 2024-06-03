using Core.Models.Enums;

namespace Core.Models;
public class ActivityTask
{
    public int Id { get; set; }
    public DateTime? Created { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public Priority Priority { get; set; }
    public Difficulty Difficulty { get; set; }
}
