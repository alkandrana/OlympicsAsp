using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OlympicsAsp.Data;
using OlympicsAsp.Models;
namespace OlympicsAsp.Controllers;

[ApiController]
[Route("[controller]")]
public class GoalsController : ControllerBase
{
    private readonly ILogger<GoalsController> _logger;
    private readonly AppDbContext _ctx;

    public GoalsController(ILogger<GoalsController> logger, AppDbContext ctx)
    {
        _logger = logger;
        _ctx = ctx;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IActionResult> GetAllGoals()
    {
        List<Goal> goals = await _ctx.Goals.ToListAsync();
        return Ok(goals);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOneGoal(int id)
    {
        Goal? goal = await _ctx.Goals.FindAsync(id);
        if (goal == null)
        {
            return NotFound();
        }
        return Ok(goal);
    }



}
