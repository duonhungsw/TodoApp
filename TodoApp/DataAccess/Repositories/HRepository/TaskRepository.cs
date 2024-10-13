using BusinessObject.Models;
using DataAccess.DAO;
using DataAccess.Repositories.IRepository;

namespace DataAccess.Repositories.HRepository;

public class TaskRepository : ITaskRepository
{
	public async Task CreateAsync(TodoTask entity) => await TaskDAO.Instance.CreateAsync(entity);

	public async Task DeleteAsync(Guid id) => await TaskDAO.Instance.DeleteAsync(id);

	public async Task<IEnumerable<TodoTask>> GetAllAsync() => await TaskDAO.Instance.GetAllAsync();

	public async Task<TodoTask> GetByIdAsync(Guid id) => await TaskDAO.Instance.GetByIdAsync(id);
	public async Task UpdateAsync(TodoTask entity) => await TaskDAO.Instance.UpdateAsync(entity);	
}
