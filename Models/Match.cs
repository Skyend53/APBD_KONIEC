using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace codeFirst_Playermatch.Models;

public class Match
{
    [Key]
    public int MatchId { get; set; }
    public int TournamentId { get; set; }
    public int MapId { get; set; }
    public DateTime MatchDate { get; set; }
    public int Team1Score { get; set; }
    public int Team2Score { get; set; }
    public decimal BestRating { get; set; }
    
    [ForeignKey(nameof(TournamentId))]
    public Tournament Tournament { get; set; } = null!;
    [ForeignKey(nameof(MapId))]
    public Map Map { get; set; } = null!;
    
    public ICollection<PlayerMatch> PlayerMatches { get; set; }
}