using Microsoft.EntityFrameworkCore;
using CommunityAPI.Data;
using CommunityAPI.Interfaces;
using CommunityAPI.Repos;
using CommunityAPI.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer( "Server=(localdb)\\MSSQLLocalDB;Database=CommunityDb;Trusted_Connection=True;"));

builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IUserService, UserService>();



var app = builder.Build();

app.MapControllers();

app.Run();
