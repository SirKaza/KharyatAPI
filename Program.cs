using KharyatAPI.Models;
using KharyatAPI.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

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
        return Results.NotFound();
    

    return Results.Ok(game);
});

app.MapPost("/api/videogames", (VideoGame game, VideoGameService service) =>
{
    if (game.Id <= 0 ||
        string.IsNullOrWhiteSpace(game.Title) ||
        string.IsNullOrWhiteSpace(game.Genre) ||
        game.ReleaseYear <= 0)
    {
        return Results.BadRequest("VideoGame values are not valid.");
    }

    var createdGame = service.Add(game);

    if (createdGame is null)
        return Results.Conflict("A videogame already existing with this ID.");

    return Results.Created($"/api/videogames/{createdGame.Id}", createdGame);
});

app.MapPut("/api/videogames/{id:int}",(int id, VideoGame updatedGame, VideoGameService service) => 
{
    if (string.IsNullOrWhiteSpace(updatedGame.Title) ||
        string.IsNullOrWhiteSpace(updatedGame.Genre) ||
        updatedGame.ReleaseYear <= 0)
    {
        return Results.BadRequest("VideoGame values are not valid.");
    }

    if (!service.Update(id, updatedGame))
        return Results.NotFound();

    return Results.Ok(service.GetById(id));
});

app.MapDelete("/api/videogames/{id:int}", (int id, VideoGameService service) =>
{
    if (!service.Delete(id))
        return Results.NotFound();

    return Results.NoContent();
});


app.Run();
