using System.ComponentModel.DataAnnotations;

namespace codeFirst_Playermatch.Models;

public class Map
{
    [Key]
    public int MapId { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    [MaxLength(120)]
    public string Type { get; set; }
    
    public ICollection<Match> matches;
}