using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace codeFirst_Playermatch.Models;

[PrimaryKey(nameof(MatchId), nameof(PlayerId))]
public class PlayerMatch
{
    public int MatchId { get; set; }
    public int PlayerId { get; set; }
    public int MVPs { get; set; }
    public decimal Rating { get; set; }
    
    [ForeignKey(nameof(MatchId))]
    public Match Match { get; set; } = null!;
    
    [ForeignKey(nameof(PlayerId))]
    public Player Player { get; set; } = null!;

}