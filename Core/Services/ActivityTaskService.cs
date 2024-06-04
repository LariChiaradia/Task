using AutoMapper;
using Core.DTOs;
using Core.Models;
using Core.Repositories.Interfaces;
using Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ActivityTaskService : IActivityTaskService
    {
        private readonly IActivityTaskRepository _repository;
        private readonly IMapper _mapper;

        public ActivityTaskService(IActivityTaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ActivityTaskDTO>> GetAllTasks()
        {
            var taskEntity = await _repository.GetAllTasks();
            return _mapper.Map<IEnumerable<ActivityTaskDTO>>(taskEntity);
        }

        public async Task<ActivityTaskDTO> GetTaskById(int id)
        {
            var taskEntity = await _repository.GetTaskById(id);
            return _mapper.Map<ActivityTaskDTO>(taskEntity);
        }

        public async Task AddTask(ActivityTaskDTO taskDTO)
        {
            var taskEntity = _mapper.Map<ActivityTask>(taskDTO);
            await _repository.AddTask(taskEntity);
            taskDTO.Id = taskEntity.Id;
        }

        public async Task UpdateTask(ActivityTaskDTO taskDTO)
        {
            var taskEntity = _mapper.Map<ActivityTask>(taskDTO);
            await _repository.UpdateTask(taskEntity);
        }

        public async Task DeleteTask(int id)
        {
            var taskEntity = await _repository.GetTaskById(id);
            await _repository.DeleteTask(taskEntity.Id);
        }
    }
}
