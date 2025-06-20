using codeFirst_Playermatch.Data;
using codeFirst_Playermatch.DTOs;
using codeFirst_Playermatch.Exceptions;
using codeFirst_Playermatch.Models;
using ExampleTest2.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace codeFirst_Playermatch.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<PlayerMatchesDto> GetMatchesForPlayer(int playerId)
    {
        var player = await _context.Players
            .Include(p => p.PlayerMatches)
                .ThenInclude(pm => pm.Match)
                    .ThenInclude(m => m.Tournament)
            .Include(p => p.PlayerMatches)
                .ThenInclude(pm => pm.Match)
                    .ThenInclude(m => m.Map)
            .FirstOrDefaultAsync(p => p.PlayerId == playerId);

        if (player == null)
            throw new NotFoundException("Player not found.");

        return new PlayerMatchesDto
        {
            PlayerId = player.PlayerId,
            FirstName = player.FirstName,
            LastName = player.LastName,
            BirthDate = player.BirthDate,
            Matches = player.PlayerMatches.Select(pm => new MatchDetailsDto
            {
                Tournament = pm.Match.Tournament.Name,
                Map = pm.Match.Map.Name,
                Date = pm.Match.MatchDate,
                MVPs = pm.MVPs,
                Rating = pm.Rating,
                Team1Score = pm.Match.Team1Score,
                Team2Score = pm.Match.Team2Score
            }).ToList()
        };
    }

    public async Task AddPlayerWithMatches(AddPlayerWithMatchesDto dto)
    {
        var existingMatches = await _context.Matches
            .Where(m => dto.Matches.Select(pm => pm.MatchId).Contains(m.MatchId))
            .ToListAsync();

        if (existingMatches.Count != dto.Matches.Count)
            throw new NotFoundException("Some matches were not found.");

        var player = new Player
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            BirthDate = dto.BirthDate,
            PlayerMatches = dto.Matches.Select(pm =>
            {
                var match = existingMatches.First(m => m.MatchId == pm.MatchId);

                // Check if the rating is better and override if necessary
                if (match.BestRating == null || pm.Rating > match.BestRating)
                {
                    match.BestRating = pm.Rating;
                }

                return new PlayerMatch
                {
                    MatchId = pm.MatchId,
                    MVPs = pm.MVPs,
                    Rating = pm.Rating
                };
            }).ToList()
        };

        await _context.Players.AddAsync(player);
        await _context.SaveChangesAsync();
    }
}