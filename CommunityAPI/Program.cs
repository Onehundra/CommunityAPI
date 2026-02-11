using Microsoft.EntityFrameworkCore;
using CommunityAPI.Data;
using CommunityAPI.Interfaces;
using CommunityAPI.Repos;
using CommunityAPI.Services;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=> { c.EnableAnnotations(); });
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer( "Server=(localdb)\\MSSQLLocalDB;Database=CommunityDb;Trusted_Connection=True;"));

builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBlogPostRepo, BlogPostRepo>();
builder.Services.AddScoped<IBlogPostService, BlogPostService>();
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICommentRepo, CommentRepo>();
builder.Services.AddScoped<ICommentService, CommentService>();


var app = builder.Build();
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();

app.Run();
