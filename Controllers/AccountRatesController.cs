using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreVue.Data;
using NetCoreVue.Models;

namespace NetCoreVue.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AccountRatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountRatesController(ApplicationDbContext context) => _context = context;

        // GET: api/AccountRates
        [HttpGet]
        public IEnumerable<AccountRate> GetAccountRates() => _context.AccountRates;

        // GET: api/AccountRates/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountRates([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accountRate = await _context.AccountRates.SingleOrDefaultAsync(m => m.AccountRateId == id);

            if (accountRate == null)
            {
                return NotFound();
            }

            return Ok(accountRate);
        }

        // GET: api/AccountRates/LatestDate/5
        [HttpGet("LatestDate/{id}")]
        public async Task<IActionResult> LatestDateAsync([FromRoute] int id)
        {
            var query = await _context.AccountRates
                .Where(r => r.CustomerAccountId == id)
                .Select(r => r.EffectiveEndDate)
                .MaxAsync();

            return Json(query);
        }

        // GET: api/AccountRates/CustomerAccountRates/5
        [HttpGet("CustomerAccountRates/{id}")]
        public IActionResult GetCustomerAccountRates([FromRoute] int id)
        {
            var query = _context.AccountRates
                .Where(r => r.CustomerAccountId == id)
                .Include(r => r.CustomerAccount)
                .OrderBy(r => r.EffectiveStartDate)
                .Select(r => new
                {
                    accountRateId       = r.AccountRateId,
                    ratePerHour         = r.RatePerHour,
                    customerAccountName = r.CustomerAccount.AccountName,
                    effectiveStartDate  = r.EffectiveStartDate,
                    effectiveEndDate    = r.EffectiveEndDate
                });

            if (!query.Any())
            {
                return NotFound();
            }

            return Json(query);
        }

        // PUT: api/AccountRates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountRate([FromRoute] int id, [FromBody] AccountRate accountRate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accountRate.AccountRateId)
            {
                return BadRequest();
            }

            _context.Entry(accountRate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountRateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(accountRate.AccountRateId);
        }

        // POST: api/AccountRates
        [HttpPost]
        public async Task<IActionResult> PostAccountRate([FromBody] AccountRate accountRate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AccountRates.Add(accountRate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostAccountRate", new {id = accountRate.AccountRateId}, accountRate);
        }

        // DELETE: api/AccountRates
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountRate([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accountRate = await _context.AccountRates.SingleOrDefaultAsync(r => r.AccountRateId == id);
            if (accountRate == null)
            {
                return NotFound();
            }

            _context.AccountRates.Remove(accountRate);
            await _context.SaveChangesAsync();

            return Ok(accountRate);
        }

        private bool AccountRateExists(int id) => _context.AccountRates
            .Any(r => r.AccountRateId == id);
    }
}