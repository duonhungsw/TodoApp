using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Models;

public class TodoTask
{
	[Key]
	public Guid Id { get; set; } = Guid.NewGuid();
	[Required]
	public string? TaskName { get; set; }
}
