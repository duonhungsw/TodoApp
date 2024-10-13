using BusinessObject.Models;

namespace DataAccess.Repositories.IRepository;

public interface ITaskRepository
{
	Task CreateAsync(TodoTask entity);
	Task DeleteAsync(Guid id);
	Task<IEnumerable<TodoTask>> GetAllAsync();
	Task<TodoTask> GetByIdAsync(Guid id);
	Task UpdateAsync(TodoTask entity);

}
