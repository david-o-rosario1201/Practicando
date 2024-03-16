using Microsoft.EntityFrameworkCore;
using Practicando.API.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextFactory<Contexto>
	(o => o.UseSqlite(builder.Configuration.GetConnectionString("ConStr")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors(options =>
{
	options.AllowAnyOrigin(); // Permitir solicitudes desde cualquier origen
	options.AllowAnyHeader(); // Permitir cualquier encabezado
	options.AllowAnyMethod(); // Permitir cualquier método HTTP
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
