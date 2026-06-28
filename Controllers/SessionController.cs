using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OlympicsAsp.Models;

namespace OlympicsAsp.Controllers
{
    [Route("sessions")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly AppDbContext _ctx;

        public SessionController(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        // GET: api/<sessionController>
        [HttpGet]
        public async Task<IActionResult> GetAllSessions()
        {
            List<Session> sessions = await _ctx.Sessions.ToListAsync();
            return Ok(sessions);
        }

        // GET api/<sessionController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneSession(int id)
        {
            Session? session = await _ctx.Sessions.FindAsync(id);
            if (session == null)
            {
                return NotFound();
            }
            return Ok(session);
        }

        // POST api/<sessionController>
        [HttpPost]
        public async Task<IActionResult> AddSession(Session session)
        {
            if (session == null)
            {
                return BadRequest();
            }
            _ctx.Sessions.Add(session);
            await _ctx.SaveChangesAsync();
            return CreatedAtAction("GetOneSession", new { id = session.Id }, session);
        }

        // PUT api/<sessionController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSession(
            [FromRoute] int id,
            [FromBody] Session session
        )
        {
            if (session == null)
            {
                return BadRequest();
            }
            Session? sessionToUpdate = await _ctx.Sessions.FindAsync(id);
            if (sessionToUpdate == null)
            {
                return NotFound();
            }

            sessionToUpdate.StartTime = session.StartTime;
            sessionToUpdate.StopTime = session.StopTime;
            sessionToUpdate.Words = session.Words;
            sessionToUpdate.GoalId = session.GoalId;

            await _ctx.SaveChangesAsync();

            return Ok(sessionToUpdate);
        }

        // DELETE api/<sessionController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSession(int id)
        {
            Session? session = await _ctx.Sessions.FindAsync(id);
            if (session == null)
            {
                return NotFound();
            }
            _ctx.Sessions.Remove(session);
            await _ctx.SaveChangesAsync();

            return NoContent();
        }
    }
}
