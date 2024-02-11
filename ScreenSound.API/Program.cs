using System.Text.Json.Serialization;

using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;

using ScreenSound.API.Endpoints;
using ScreenSound.Domain.Entities;
using ScreenSound.Infrastructure.Persistences.Contexts;
using ScreenSound.Infrastructure.Persistences.Repositories;

var builder = WebApplication.CreateBuilder(args);

var azureConnectionString = builder.Configuration.GetValue<string>("AzureConfig:ConnectionString");

builder.Host.ConfigureAppConfiguration(config =>
{
    var settings = config.Build();
    config.AddAzureAppConfiguration(azureConnectionString);
});

var connectionString = builder.Configuration.GetConnectionString("ScreenSound");

// Add services to the container.
builder.Services.AddAuthorization();

builder.Services.AddDbContext<ScreenSoundContext>(opts =>
{
    opts.UseSqlServer(connectionString)
        .UseLazyLoadingProxies();
});

builder.Services.AddTransient<IGenericRepository<Artist>, GenericRepository<Artist>>();
builder.Services.AddTransient<IGenericRepository<Music>, GenericRepository<Music>>();
builder.Services.AddTransient<IGenericRepository<Genre>, GenericRepository<Genre>>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<JsonOptions>(opts =>
{
    opts.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddCors();

var app = builder.Build();

app.UseCors(opts =>
{
    opts.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
});

app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.AddArtistsEndpoints()
   .AddMusicsEndpoints()
   .AddGenreEndpoints();

app.Run();