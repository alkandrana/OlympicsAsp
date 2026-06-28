using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OlympicsAsp.Data;
using OlympicsAsp.Models;
namespace OlympicsAsp.Controllers;

[ApiController]
[Route("[controller]")]
public class GoalsController : ControllerBase
{
    private readonly AppDbContext _ctx;

    public GoalsController(AppDbContext ctx)
    {
        _ctx = ctx;
    }

    [HttpGet]
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

    [HttpPost]
    public async Task<IActionResult> AddGoal(Goal goal)
    {
        _ctx.Goals.Add(goal);
        await _ctx.SaveChangesAsync();
        return CreatedAtAction("GetOneGoal", new { id = goal.Id }, goal);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateGoal(int id, Goal goal)
    {
        if (goal == null)
        {
            return BadRequest();
        }
        Goal? goalToUpdate = await _ctx.Goals.FindAsync(id);
        if (goalToUpdate == null)
        {
            return NotFound();
        }
        goalToUpdate.Name = goal.Name;
        goalToUpdate.StartDate = goal.StartDate;
        goalToUpdate.Deadline = goal.Deadline;
        _ctx.Goals.Update(goalToUpdate);
        await _ctx.SaveChangesAsync();
        
        return Ok(goalToUpdate);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGoal(int id)
    {
        Goal? goal = await _ctx.Goals.FindAsync(id);
        if (goal == null)
        {
            return NotFound();
        }
        _ctx.Goals.Remove(goal);
        await _ctx.SaveChangesAsync();
        
        return NoContent();
    }
}
