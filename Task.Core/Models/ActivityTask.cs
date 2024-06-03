using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Core.Models.Enums;

namespace Task.Core.Models;

public class ActivityTask
{
    public int Id { get; set; }
    public DateTime? Created { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public Priority Priority { get; set; }
    public Difficulty Difficulty { get; set; }
}
