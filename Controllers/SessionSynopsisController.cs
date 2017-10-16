using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreVue.Data;
using NetCoreVue.Models;

namespace NetCoreVue.Controllers
{
    [Produces("application/json")]
    [Route("api/SessionSynopsis")]
    public class SessionSynopsisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SessionSynopsisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SessionSynopsis
        [HttpGet]
        public IEnumerable<SessionSynopsis> GetSessionSynopses()
        {
            return _context.SessionSynopses;
        }

        // GET: api/SessionSynopsis/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSessionSynopsis([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sessionSynopsis = await _context.SessionSynopses.SingleOrDefaultAsync(m => m.SessionSynopsisId == id);

            if (sessionSynopsis == null)
            {
                return NotFound();
            }

            return Ok(sessionSynopsis);
        }

        // PUT: api/SessionSynopsis/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSessionSynopsis([FromRoute] int id, [FromBody] SessionSynopsis sessionSynopsis)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sessionSynopsis.SessionSynopsisId)
            {
                return BadRequest();
            }

            _context.Entry(sessionSynopsis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SessionSynopsisExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SessionSynopsis
        [HttpPost]
        public async Task<IActionResult> PostSessionSynopsis([FromBody] SessionSynopsis sessionSynopsis)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SessionSynopses.Add(sessionSynopsis);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSessionSynopsis", new { id = sessionSynopsis.SessionSynopsisId }, sessionSynopsis);
        }

        // DELETE: api/SessionSynopsis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSessionSynopsis([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sessionSynopsis = await _context.SessionSynopses.SingleOrDefaultAsync(m => m.SessionSynopsisId == id);
            if (sessionSynopsis == null)
            {
                return NotFound();
            }

            _context.SessionSynopses.Remove(sessionSynopsis);
            await _context.SaveChangesAsync();

            return Ok(sessionSynopsis);
        }

        private bool SessionSynopsisExists(int id)
        {
            return _context.SessionSynopses.Any(e => e.SessionSynopsisId == id);
        }
    }
}