using Core.DTOs;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityTaskController : ControllerBase
    {
        private readonly IActivityTaskService _service;

        public ActivityTaskController(IActivityTaskService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityTaskDTO>>> GetAllTasks()
        {
            var tasksDTO = await _service.GetAllTasks();
            if(tasksDTO is null)
                return NotFound("Tasks não encontradas.");
            return Ok(tasksDTO);
        }

        [HttpGet("{id:int}", Name ="GetTask")]
        public async Task<ActionResult<ActivityTaskDTO>> GetTaskById(int id)
        {
            var taskDTO = await _service.GetTaskById(id);
            if (taskDTO is null)
                return NotFound("Task não encontrada.");
            return Ok(taskDTO);
        }

        [HttpPost]
        public async Task<ActionResult<ActivityTaskDTO>> AddTask([FromBody] ActivityTaskDTO taskDTO)
        {
            if (taskDTO is null)
                return BadRequest("Dados Inválidos");
            await _service.AddTask(taskDTO);
            return new CreatedAtRouteResult("GetTask", new { id = taskDTO.Id }, taskDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ActivityTaskDTO>> UpdateTask(int id, [FromBody] ActivityTaskDTO taskDTO)
        {
            if (taskDTO is null)
                return BadRequest("Dados Inválidos");
            if (taskDTO.Id != id)
                return BadRequest("Dados Inválidos");

            await _service.UpdateTask(taskDTO);
            return Ok(taskDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ActivityTaskDTO>> DeleteTask(int id)
        {
            var taskDTO = await _service.GetTaskById(id);
            if(taskDTO is null)
                return NotFound("Task não encontrada.");
            await _service.DeleteTask(id);
            return Ok(taskDTO);
        }
    }
}
