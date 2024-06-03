using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interface;

public interface IActivityTaskRepository
{
    Task<IEnumerable<ActivityTask>> GetAllTasks();
    Task<ActivityTask> GetTaskById(int id);
    Task<ActivityTask> AddTask(ActivityTask task);
    Task<ActivityTask> UpdateTask(ActivityTask task);
    Task<ActivityTask> DeleteTask(int id);
}
