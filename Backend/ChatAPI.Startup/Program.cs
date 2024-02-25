using ChatAPI.Data;
using ChatAPI.Startup;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//custom configuration of settings
builder.Services.Configure<PersistenceSettings>(builder.Configuration.GetSection("connectionString"));
//Db register
builder.Services.AddDbContext<ChatAppDbContext>(o => o.UseNpgsql(@builder.Configuration.GetSection("PersistenceSettings")["connectionString"], 
    b => b.MigrationsAssembly("ChatAPI.Data")));
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