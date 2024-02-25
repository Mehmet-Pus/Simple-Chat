using ChatAPI.Core;
using ChatAPI.Data;
using ChatAPI.Startup;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//custom config
builder.Services.Configure<PersistenceSettings>(builder.Configuration.GetSection("PersistenceSettings"));

var serviceProvider = builder.Services.BuildServiceProvider();
var providerOptions = serviceProvider.GetService<IOptions<PersistenceSettings>>()?.Value ??
                      throw new InvalidOperationException("The persistence provider options cannot be null.");

//Db register
builder.Services.AddDbContext<ChatAppDbContext>(o => o.UseNpgsql(providerOptions.GetConnectionString(), 
    b => b.MigrationsAssembly("ChatAPI.Data")));



//dependency injection
builder.Services.AddSingleton<PersistenceSettings>();






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