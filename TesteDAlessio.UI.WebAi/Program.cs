using Microsoft.EntityFrameworkCore;
using TesteDAlessio.Domain.Repository;
using TesteDAlessio.Infrastructure.DBContext;
using TesteDAlessio.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TesteDAlessioDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("TesteDAlessioDB")));

builder.Services.AddScoped<ICargoRepository, CargoRepository>();
builder.Services.AddScoped<IContatoRepository, ContatoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

