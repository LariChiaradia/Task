using Core.Models;

namespace Core.Repositories.Interfaces;

public interface IActivityTaskRepository
{
    Task<IEnumerable<ActivityTask>> GetAllTasks();
    Task<ActivityTask> GetTaskById(int id);
    Task<ActivityTask> AddTask(ActivityTask task);
    Task<ActivityTask> UpdateTask(ActivityTask task);
    Task<ActivityTask> DeleteTask(int id);
}
