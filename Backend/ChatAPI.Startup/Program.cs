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

//custom configuration of settings
builder.Services.Configure<PersistenceSettings>(builder.Configuration.GetSection("PersistenceSettings"));
//Db register
builder.Services.AddDbContext<ChatAppDbContext>(o => o.UseNpgsql(@builder.Configuration.GetSection("PersistenceSettings")[""], 
    b => b.MigrationsAssembly("ChatAPI.Data")));


var serviceProvider = builder.Services.BuildServiceProvider();
var providerOptions = serviceProvider.GetService<IOptions<PersistenceSettings>>()?.Value ??
                      throw new InvalidOperationException("The persistence provider options cannot be null.");
providerOptions.GetConnectionString();



//dependency injection for once, making it available during the course of the app
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