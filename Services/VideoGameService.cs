using KharyatAPI.Models;

namespace KharyatAPI.Services;

public class VideoGameService
{
    private readonly List<VideoGame> games = new()
    {
        new VideoGame
        {
            Id = 1,
            Title = "Hollow Knight",
            Genre = "Metroidvania",
            ReleaseYear = 2017
        },
        new VideoGame
        {
            Id = 2,
            Title = "Minecraft",
            Genre = "Sandbox",
            ReleaseYear = 2011
        },
        new VideoGame
        {
            Id = 3,
            Title = "Elden Ring",
            Genre = "Action RPG",
            ReleaseYear = 2022
        }
    };

    public List<VideoGame> GetAll()
    {
        return games;
    }

    public VideoGame? GetById(int id)
    {
        return games.FirstOrDefault(game => game.Id == id);
    }

    public VideoGame? Add(VideoGame game)
    {
        if (games.Any(existing => existing.Id == game.Id))
        {
            return null;
        }

        games.Add(game);

        return game;
    }

    public bool Update(int id, VideoGame updatedGame)
    {
        var game = GetById(id);

        if (game is null)
            return false;

        game.Title = updatedGame.Title;
        game.Genre = updatedGame.Genre;
        game.ReleaseYear = updatedGame.ReleaseYear;

        return true;
    }

    public bool Delete(int id)
    {
        var game = GetById(id);

        if(game is null)
            return false;

        games.Remove(game);

        return true;
    }
}