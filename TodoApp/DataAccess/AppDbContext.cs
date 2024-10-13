using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataLayer;

public class AppDbContext : DbContext
{
	public AppDbContext() { }
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

	public virtual DbSet<TodoTask> TodoTasks { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		var builder = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
		IConfiguration configuration = builder.Build();
		optionsBuilder.UseSqlServer(configuration.GetConnectionString("Database"));
	}
}