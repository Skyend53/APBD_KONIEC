using codeFirst_Playermatch.Models;
using Microsoft.EntityFrameworkCore;

namespace codeFirst_Playermatch.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Map> Maps { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<PlayerMatch> PlayerMatches { get; set; }
    public DbSet<Tournament> Tournaments { get; set; }

    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Przykładowe dane dla tabeli Map
        modelBuilder.Entity<Map>().HasData(new List<Map>
        {
            new Map { MapId = 1, Name = "Inferno", Type = "Competitive" },
            new Map { MapId = 2, Name = "Mirage", Type = "Competitive" }
        });

        // Przykładowe dane dla tabeli Tournament
        modelBuilder.Entity<Tournament>().HasData(new List<Tournament>
        {
            new Tournament { TournamentId = 1, Name = "CS2 Summer Cup", StartDate = DateTime.Parse("2025-07-01"), EndDate = DateTime.Parse("2025-07-10") }
        });

        // Przykładowe dane dla tabeli Match
        modelBuilder.Entity<Match>().HasData(new List<Match>
        {
            new Match
            {
                MatchId = 1, TournamentId = 1, MapId = 1,
                MatchDate = DateTime.Parse("2025-07-02T15:00:00"),
                Team1Score = 16, Team2Score = 12, BestRating = 1.55m
            },
            new Match
            {
                MatchId = 2, TournamentId = 1, MapId = 2,
                MatchDate = DateTime.Parse("2025-07-03T18:00:00"),
                Team1Score = 10, Team2Score = 16, BestRating = 1.32m
            }
        });

        // Przykładowe dane dla tabeli Player
        modelBuilder.Entity<Player>().HasData(new List<Player>
        {
            new Player { PlayerId = 1, FirstName = "Alex", LastName = "Smith", BirthDate = DateTime.Parse("2000-05-20") }
        });

        // Przykładowe dane dla tabeli PlayerMatch
        modelBuilder.Entity<PlayerMatch>().HasData(new List<PlayerMatch>
        {
            new PlayerMatch { MatchId = 1, PlayerId = 1, MVPs = 3, Rating = 1.25m },
            new PlayerMatch { MatchId = 2, PlayerId = 1, MVPs = 2, Rating = 1.10m }
        });
    }
}