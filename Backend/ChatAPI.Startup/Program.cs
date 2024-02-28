using System.Text;
using ChatAPI.Core;
using ChatAPI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//custom config for Persistence Settings
builder.Services.Configure<PersistenceSettings>(builder.Configuration.GetSection("PersistenceSettings"));

var serviceProvider = builder.Services.BuildServiceProvider();
var providerOptions = serviceProvider.GetService<IOptions<PersistenceSettings>>()?.Value ??
    throw new InvalidOperationException("The persistence provider options cannot be null.");
//Jwt Part
var providerOptions2 = serviceProvider.GetService<IOptions<AuthenticationSettings>>()?.Value ??
                       throw new InvalidOperationException("error");
var key = Encoding.ASCII.GetBytes(providerOptions2.GetJwtSetting());
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

//Db register
builder.Services.AddDbContext<ChatAppDbContext>(
    o => o.UseNpgsql(providerOptions.GetConnectionString(),
    b => b.MigrationsAssembly("ChatAPI.Data")));


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