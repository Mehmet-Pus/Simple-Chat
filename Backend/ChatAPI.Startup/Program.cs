using System.Text;
using ChatAPI.Core.Settings;
using ChatAPI.Data;
using ChatAPI.Data.Models;
using ChatAPI.Startup.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Injection for AuthController and TokenService
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddIdentity<User, UserRole>()
    .AddEntityFrameworkStores<ChatAppDbContext>()
    .AddDefaultTokenProviders();

//custom config for Persistence and Auth Settings
builder.Services.Configure<PersistenceSettings>(builder.Configuration.GetSection("PersistenceSettings"));
builder.Services.Configure<AuthenticationSettings>(builder.Configuration.GetSection("AuthenticationSettings"));

var serviceProvider = builder.Services.BuildServiceProvider();
var providerOptions = serviceProvider.GetService<IOptions<PersistenceSettings>>()?.Value ??
    throw new InvalidOperationException("The persistence provider options cannot be null.");
//Jwt Part
var authOptions = serviceProvider.GetService<IOptions<AuthenticationSettings>>()?.Value ??
                       throw new InvalidOperationException("error");

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
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(authOptions.SecretKey)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidIssuer = authOptions.Issuer,
            ValidAudience = authOptions.Audience,
        };
    });
builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
{
    options.TokenLifespan = TimeSpan.FromMinutes(Convert.ToInt32(authOptions.DurationInMinutes));
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