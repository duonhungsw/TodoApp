using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;

namespace DataAccess.DAO;

public class TaskDAO : SingletonBase<TaskDAO>, CrudBase<TodoTask>
{
	public async Task CreateAsync(TodoTask entity)
	{
		await appDbContext.TodoTasks.AddAsync(entity);
		await appDbContext.SaveChangesAsync();
	}

	public async Task DeleteAsync(Guid id)
	{
		var task = await appDbContext.TodoTasks.FirstOrDefaultAsync(t => t.Id == id);
		if (task != null)
		{
			appDbContext.TodoTasks.Remove(task);
			await appDbContext.SaveChangesAsync();
		}

	}

	public async Task<IEnumerable<TodoTask>> GetAllAsync()
	{
		try
		{
			var taskList = await appDbContext.TodoTasks.ToListAsync();
			return taskList;
		}
		catch (Exception ex)
		{
			throw new NotFoundException("Error to loading tasks");
		}
	}

	public async Task<TodoTask> GetByIdAsync(Guid id)
	{
		var task = await appDbContext.TodoTasks.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
		if (task != null)
		{
			return task;
		}
		return null;
	}

	public async Task UpdateAsync(TodoTask entity)
	{
		var taskExisting = await appDbContext.TodoTasks.FirstOrDefaultAsync(t => t.Id == entity.Id);
		if (taskExisting != null)
		{
			appDbContext.Entry(taskExisting).CurrentValues.SetValues(entity);
			await appDbContext.SaveChangesAsync();
		}
	}
}