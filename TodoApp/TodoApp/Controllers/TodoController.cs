using BusinessObject.Models;
using DataAccess.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace TodoApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoController : ControllerBase
{
	private readonly ITaskRepository taskRepository;
	public TodoController(ITaskRepository taskRepository)
	{
		this.taskRepository = taskRepository;
	}
	[HttpGet("AllTasks")]
	public async Task<ActionResult<IEnumerable<TodoTask>>> GetAll()
	{
		var list = await taskRepository.GetAllAsync();
		if (list != null)
		{
			return Ok(list);
		}
		return BadRequest();
	}
	[HttpPost("AddTask")]
	public async Task<IActionResult> AddTask(TodoTask todo)
	{
		try
		{
			await taskRepository.CreateAsync(todo);
			return Ok();
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}
	[HttpPut("UpdateTask")]
	public async Task<IActionResult> UpdateTask(TodoTask todo)
	{
		try
		{
			await taskRepository.UpdateAsync(todo);
			return Ok();
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}
	[HttpDelete("DeleteTask")]
	public async Task<IActionResult> DeleteTask([FromQuery] Guid id)
	{
		try
		{
			await taskRepository.DeleteAsync(id);
			return Ok();
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}
}
