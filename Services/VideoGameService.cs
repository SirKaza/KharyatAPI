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
}