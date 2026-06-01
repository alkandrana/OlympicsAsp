using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OlympicsAsp.Controllers
{
    [Route("goals")]
    [ApiController]
    public class GoalController : ControllerBase
    {
        private readonly AppDbContext _ctx;

        public GoalController(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        // GET: api/<GoalController>
        [HttpGet]
        public async Task<IActionResult> GetAllGoals()
        {
            List<Goal> goals = await _ctx.Goals.ToListAsync();
            return Ok(goals);
        }

        // GET api/<GoalController>/5
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

        // POST api/<GoalController>
        [HttpPost]
        public async Task<IActionResult> AddGoal(Goal goal)
        {
            if (goal == null)
            {
                return BadRequest();
            }
            _ctx.Goals.Add(goal);
            await _ctx.SaveChangesAsync();
            return CreatedAtAction("GetOneGoal", new { id = goal.Id }, goal);
        }

        // PUT api/<GoalController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGoal([FromRoute] int id, [FromBody] Goal goal)
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
            goalToUpdate.Target = goal.Target;

            await _ctx.SaveChangesAsync();

            return Ok(goalToUpdate);
        }

        // DELETE api/<GoalController>/5
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
}
