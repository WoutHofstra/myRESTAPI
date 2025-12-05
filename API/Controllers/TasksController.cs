using Microsoft.AspNetCore.Mvc;
using myRESTAPI.API.DTOs;

/*
This file controls all the tasks the user is able to access. 

The user can:
    - get all tasks
    - get tasks by id
    - create tasks
    - update tasks
    - delete tasks
    - mark tasks as completed

This file only validates incoming data, maps DTOs, calls services, then returns results. 
*/

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
    public async Task<IActionResult> GetTaskById(int id)
    {
        var task = await _taskService.GetTaskByIdAsync(id);
        if (task == null)
        {
            return NotFound();
        }
        return Ok(task);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask(CreateTaskDTO dto)
    {
        var task = await _taskService.CreateTaskAsync(dto);
        return CreatedAtAction(nameof(GetTaskById), new { id = task.id }, task);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTask(int id, UpdateTaskDto dto)
    {
        var task = await _taskService.UpdateTaskAsync(id, dto);
        if (task == null) 
        {
            return NotFound();
        }
        return Ok(task);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var deleted = _taskService.DeleteTaskAsync(id);
        if (deleted == true)
        {
            return NoContent();
        }
        return NotFound();
    }

    [HttpPut]
    public async Task<IActionResult> CompleteTask(int id)
    {
        var task = _taskService.CompleteTaskAsync(id);
        if (task == null)
        {
            return NotFound();
        }
        return task;
    } 
}