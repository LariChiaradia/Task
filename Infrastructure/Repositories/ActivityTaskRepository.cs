using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Infrastructure.Context;
using Infrastructure.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ActivityTaskRepository : IActivityTaskRepository
    {
        private readonly AppDbContext _context;

        public ActivityTaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ActivityTask>> GetAllTasks()
        {
            var activityTasks = await _context.ActivityTasks.ToListAsync();
            return activityTasks;
        }

        public async Task<ActivityTask> GetTaskById(int id)
        {
            var activityTask = await _context.ActivityTasks.Where(t => t.Id == id).FirstOrDefaultAsync();
            return activityTask;
        }

        public async Task<ActivityTask> AddTask(ActivityTask task)
        {
             _context.ActivityTasks.Add(task);
             await _context.SaveChangesAsync();
            return task;
        }

        public async Task<ActivityTask> UpdateTask(ActivityTask task)
        {
            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return task;
        }
        public async Task<ActivityTask> DeleteTask(int id)
        {
            var task = await GetTaskById(id);
            _context.Remove(task);
            await _context.SaveChangesAsync();
            return task;
        }
    }
}
