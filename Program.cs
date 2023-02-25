using Microsoft.EntityFrameworkCore;

using QuesFight.Data;
using QuesFight.Services;



var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

// Add services to the container.
builder.Services.AddCors(o => o.AddPolicy("Policy", builder =>
    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddControllers();

string connectionString = config.GetConnectionString(config.GetValue<string>("TargetConnectionString"));
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(connectionString), ServiceLifetime.Transient);
AppStart.ConfigRepositories(builder.Services);

AppStart.ConfigJwt(config, builder.Services);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
