using System.Text.Json.Serialization;

using Microsoft.AspNetCore.Http.Json;

using ScreenSound.API.Endpoints;
using ScreenSound.Domain.Entities;
using ScreenSound.Infrastructure.Persistences.Contexts;
using ScreenSound.Infrastructure.Persistences.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthorization();
builder.Services.AddDbContext<ScreenSoundContext>();
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

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.AddArtistsEndpoints()
   .AddMusicsEndpoints()
   .AddGenreEndpoints();

app.Run();