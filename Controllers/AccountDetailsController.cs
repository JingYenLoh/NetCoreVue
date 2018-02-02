using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetCoreVue.Data;
using NetCoreVue.Models;

namespace NetCoreVue.Controllers
{
    [Produces("application/json")]
    [Route("api/AccountDetails")]
    public class AccountDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public AccountDetailsController(
            ApplicationDbContext context,
            ILogger<AccountDetailsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/AccountDetails
        [HttpGet]
        public IEnumerable<AccountDetail> GetAccountDetails()
        {
            return _context.AccountDetails;
        }

        // GET: api/AccountDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accountDetail = await _context.AccountDetails.SingleOrDefaultAsync(m => m.AccountDetailId == id);

            if (accountDetail == null)
            {
                return NotFound();
            }

            return Ok(accountDetail);
        }

        // PUT: api/AccountDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountDetail([FromRoute] int id, [FromBody] AccountDetail accountDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accountDetail.AccountDetailId)
            {
                return BadRequest();
            }

            _context.Entry(accountDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountDetailExists(id))
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

        // POST: api/AccountDetails
        [HttpPost]
        public async Task<IActionResult> PostAccountDetail([FromBody] AccountDetail accountDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AccountDetails.Add(accountDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccountDetail", new { id = accountDetail.AccountDetailId }, accountDetail);
        }

        // POST: api/AccountDetails/5
        [HttpPost("{id}")]
        public async Task<IActionResult> PostAccountDetail([FromRoute] int id, [FromBody] AccountDetail accountDetail)
        {
            _logger.LogCritical(666420, "Nin ninama cb", ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var latestDate = await _context.AccountRates
                .Where(ar => ar.CustomerAccountId == id)
                .Select(ar => ar.EffectiveEndDate)
                .DefaultIfEmpty(DateTime.Now)
                .MaxAsync();

            if (accountDetail.EffectiveStartDate > accountDetail.EffectiveEndDate)
            {
                return BadRequest("End date cannot be earlier than start date.");
            }

            try
            {
                _context.AccountDetails.Add(accountDetail);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }

            return CreatedAtAction("PostAccountDetail", new {id = accountDetail.AccountDetailId}, accountDetail);
        }

        // DELETE: api/AccountDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accountDetail = await _context.AccountDetails.SingleOrDefaultAsync(m => m.AccountDetailId == id);
            if (accountDetail == null)
            {
                return NotFound();
            }

            _context.AccountDetails.Remove(accountDetail);
            await _context.SaveChangesAsync();

            return Ok(accountDetail);
        }

        private bool AccountDetailExists(int id)
        {
            return _context.AccountDetails.Any(e => e.AccountDetailId == id);
        }
    }
}