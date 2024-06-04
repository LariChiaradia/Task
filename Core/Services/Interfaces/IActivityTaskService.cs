using Core.DTOs;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IActivityTaskService
    {
        Task<IEnumerable<ActivityTaskDTO>> GetAllTasks();
        Task<ActivityTaskDTO> GetTaskById(int id);
        Task AddTask(ActivityTaskDTO taskDTO);
        Task UpdateTask(ActivityTaskDTO taskDTO);
        Task DeleteTask(int id);
    }
}
