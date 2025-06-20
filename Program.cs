using codeFirst_Playermatch.Data;
using codeFirst_Playermatch.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<IDbService, DbService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();


// dotnet add package Microsoft.EntityFrameworkCore 
//dotnet add package Microsoft.EntityFrameworkCore.Design 
  //  dotnet add package Microsoft.EntityFrameworkCore.SqlServer 
    //dotnet ef migrations add "migration name" dotnet ef database update