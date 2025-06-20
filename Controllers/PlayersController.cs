using System.ComponentModel.DataAnnotations;
using codeFirst_Playermatch.DTOs;
using codeFirst_Playermatch.Exceptions;
using codeFirst_Playermatch.Services;
using ExampleTest2.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace codeFirst_Playermatch.Controllers;

[ApiController]
[Route("api/players")]
public class PlayersController : ControllerBase
{
    private readonly IDbService _dbService;

    public PlayersController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{id}/matches")]
    public async Task<IActionResult> GetPlayerMatches(int id)
    {
        try
        {
            var result = await _dbService.GetMatchesForPlayer(id);
            return Ok(result);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddPlayer(AddPlayerWithMatchesDto dto)
    {
        try
        {
            await _dbService.AddPlayerWithMatches(dto);
            return Created("api/players", null);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Message);
        }
    }
}