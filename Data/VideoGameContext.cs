using Microsoft.EntityFrameworkCore;
using KharyatAPI.Models;

namespace KharyatAPI.Data;

public class VideoGameContext : DbContext
{
    public VideoGameContext(DbContextOptions<VideoGameContext> options)
    : base (options)
    {
    }

    public DbSet<VideoGame> VideoGames { get; set; }
}