using KharyatAPI.Models;
using KharyatAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<VideoGameService>();

var app = builder.Build();

app.MapGet("/", () => "It Works!");

app.MapGet("/api/videogames", (VideoGameService service) =>
{
    return Results.Ok(service.GetAll());
});

app.MapGet("/api/videogames/{id:int}", (int id, VideoGameService service) =>
{
    var game = service.GetById(id);

    if(game is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(game);
});

app.Run();
