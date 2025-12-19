using Microsoft.AspNetCore.Mvc;
using myRESTAPI.Application.DTOs;
using myRESTAPI.Application.Services;
using System.Threading.Tasks;
using myRESTAPI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/v1/tasks")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTasks()
    {
        var tasks = await _taskService.GetAllTasksAsync();
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public async Task<IActionResult> GetTaskById(int id)
    {
        var task = await _taskService.GetTaskById(id);
        if (task == null)
        {
            return NotFound();
        }
        return Ok(task);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] CreateTaskDTO dto)
    {
        var task = await _taskService.CreateTaskAsync(dto);
        return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(int id, [FromBody] UpdateTaskDTO dto)
    {
        var task = await _taskService.UpdateTaskAsync(id, dto);
        if (task == null) 
        {
            return NotFound();
        }
        return Ok(task);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var task = await _taskService.GetTaskById(id);
        var deleted = await _taskService.DeleteTaskAsync(id);
        if (deleted && task != null)
        {
            return Ok(task);
        }
        return NotFound();
    }

    [HttpPut("{id}/complete")]
    public async Task<IActionResult> CompleteTask(int id)
    {
        var task = await _taskService.CompleteTaskAsync(id);
        if (task == null)
        {
            return NotFound();
        }
        return Ok(task);
    } 

    private readonly TaskDbContext _db;

    public TasksController(TaskDbContext db)
    {
        _db = db;
    }


    [HttpGet("debug-db")]
    public async Task<IActionResult> DebugDb()
    {
        var server = _db.Database.GetDbConnection().DataSource;
        var dbName = _db.Database.GetDbConnection().Database;
        return Ok(new {server,dbName});
    }
}