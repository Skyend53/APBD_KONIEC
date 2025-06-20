namespace codeFirst_Playermatch.DTOs;

public class AddPlayerWithMatchesDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public List<PlayerMatchDto> Matches { get; set; } = null!;
}

public class PlayerMatchDto
{
    public int MatchId { get; set; }
    public int MVPs { get; set; }
    public decimal Rating { get; set; }
}

public class PlayerMatchesDto
{
    public int PlayerId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public List<MatchDetailsDto> Matches { get; set; } = null!;
}

public class MatchDetailsDto
{
    public string Tournament { get; set; } = null!;
    public string Map { get; set; } = null!;
    public DateTime Date { get; set; }
    public int MVPs { get; set; }
    public decimal Rating { get; set; }
    public int Team1Score { get; set; }
    public int Team2Score { get; set; }
}