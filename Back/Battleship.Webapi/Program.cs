using Battleship.Webapi.Controllers;
using Battleship.Webapi.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContextPool<PlayerDbContext>(opt =>
{
   string cs = "Server=localhost;Port=3306;Database=battleshipUser;Uid=battleshipUser;Pwd=battleshipUser;";
   opt.UseMySql(cs, ServerVersion.AutoDetect(cs));
});

var app = builder.Build();

// app.MapGet("/", () => "Hello World!");

app.UseAuthorization();

app.MapControllers();

app.Run();
