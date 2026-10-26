using KharyatAPI.Models;

namespace KharyatAPI.Services;

public static class VideoGameValidator
{
    public static Dictionary<string, string[]> Validate(VideoGame game)
    {
        var errors = new Dictionary<string, string[]>();

        if (game.Id <= 0)
        {
            errors[nameof(game.Id)] = new[]{"The game id is not valid."};
        }

        if (string.IsNullOrWhiteSpace(game.Title))
        {
            errors[nameof(game.Title)] = new[]{"The title is mandatory."};
        }
        else if (game.Title.Length > 100)
        {
            errors[nameof(game.Title)] = new[]{"The title cannot exceed 100 characters."};
        }

        if (string.IsNullOrWhiteSpace(game.Genre))
        {
            errors[nameof(game.Genre)] = new[]{"The genre is mandatory."};
        }

        if (game.ReleaseYear < 1950 || game.ReleaseYear > DateTime.Now.Year + 5)
        {
            errors[nameof(game.ReleaseYear)] = new[] {"The release year is not valid."};
        }

        return errors;
    }
}