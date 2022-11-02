using DSM.Music.WebApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Console.WriteLine("CONNECTION STRING: " + builder.Configuration["MusicDbConnection"]);

builder.Services.AddDbContext<MusicDbContext>(options => 
{  
    options.UseMySql(builder.Configuration["MusicDbConnection"], 
    ServerVersion.AutoDetect(builder.Configuration["MusicDbConnection"]));
});

Console.WriteLine("SALES API URL: " + builder.Configuration["SalesDataApiUrl"]);

builder.Services.AddHttpClient("SalesData", httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration["SalesDataApiUrl"]);
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
