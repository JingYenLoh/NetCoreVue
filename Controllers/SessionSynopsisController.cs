using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreVue.Data;
using NetCoreVue.Models;

namespace NetCoreVue.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/SessionSynopsis")]
    public class SessionSynopsisController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public SessionSynopsisController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/SessionSynopsis
        [HttpGet]
        public IActionResult GetSessionSynopses()
        {
            var query = _context.SessionSynopses
                .Include(ss => ss.UpdatedBy)
                .Include(ss => ss.CreatedBy)
                .Select(ss => new
                {
                    sessionSynopsisId = ss.SessionSynopsisId,
                    sessionSynopsisName = ss.SessionSynopsisName,
                    createdBy = ss.CreatedBy.FullName,
                    isVisible = ss.IsVisible,
                    updatedBy = ss.UpdatedBy.FullName
                });

            return Ok(query);
        }

        // GET: api/SessionSynopsis/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSessionSynopsis([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sessionSynopsis = await _context.SessionSynopses
                .SingleOrDefaultAsync(m => m.SessionSynopsisId == id);

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
                throw;
            }
            catch (DbUpdateException e) when (e.InnerException.Message.Contains("SessionSynopsis_SessionSynopsisName_UniqueConstraint"))
            {
                var response = new { message = "A session synopsis with the same name already exists." };
                return StatusCode(409, response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(sessionSynopsis.SessionSynopsisName);
        }

        // POST: api/SessionSynopsis
        [HttpPost]
        public async Task<IActionResult> PostSessionSynopsis([FromBody] SessionSynopsis sessionSynopsis)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.SessionSynopses.Add(sessionSynopsis);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e) when (e.InnerException.Message.Contains("SessionSynopsis_SessionSynopsisName_UniqueConstraint"))
            {
                    var response = new { message = "A session synopsis with the same name already exists." };
                    return StatusCode(409, response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

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