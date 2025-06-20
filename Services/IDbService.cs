using codeFirst_Playermatch.DTOs;

namespace codeFirst_Playermatch.Services;

public interface IDbService
{
    Task<PlayerMatchesDto> GetMatchesForPlayer(int playerId);
    Task AddPlayerWithMatches(AddPlayerWithMatchesDto dto);
}