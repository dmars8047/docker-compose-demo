using DSM.SalesData.WebApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Console.WriteLine("CONNECTION STRING: " + builder.Configuration["SalesDataDbConnection"]);

builder.Services.AddDbContext<SalesDbContext>(options => 
{  
    options.UseMySql(builder.Configuration["SalesDataDbConnection"], 
    ServerVersion.AutoDetect(builder.Configuration["SalesDataDbConnection"]));
});

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
