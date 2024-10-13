
using DataAccess.Repositories.HRepository;
using DataAccess.Repositories.IRepository;
using DataLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add cors
builder.Services.AddCors(p => p.AddPolicy("TodoApp", policy =>
{
	policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

//Add db and repositories
builder.Services.AddSingleton(typeof(AppDbContext));
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("TodoApp");

app.UseAuthorization();


app.MapControllers();

app.Run();
