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
    var errors = VideoGameValidator.Validate(game);

    if (errors.Count > 0)
    {
        return Results.ValidationProblem(errors);
    }

    var createdGame = service.Add(game);

    if (createdGame is null)
        return Results.Conflict("A videogame already existing with this ID.");

    return Results.Created($"/api/videogames/{createdGame.Id}", createdGame);
});

app.MapPut("/api/videogames/{id:int}",(int id, VideoGame updatedGame, VideoGameService service) => 
{
    var errors = VideoGameValidator.Validate(updatedGame);

    if (errors.Count > 0)
    {
        return Results.ValidationProblem(errors);
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
