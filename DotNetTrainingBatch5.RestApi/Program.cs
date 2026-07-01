using DotNetTrainingBatch5.Database.Models;
using DotNetTrainingBatch5.Domain.Features.Blog;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


//UI -> BL -> DB
// But it's reverse in here 
// Create the 
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    // this configureation come/needtoinput'ConnectionStrings'  from/in appsettings.json 
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
});
//builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<IBlogService, BlogV2Service>();



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
