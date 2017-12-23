using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreVue.Data;
using NetCoreVue.Models;
using NetCoreVue.Models.CustomerAccountViewModels;

namespace NetCoreVue.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/CustomerAccounts")]
    public class CustomerAccountsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerAccountsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerAccounts
        [HttpGet]
        public IActionResult GetCustomerAccounts()
        {
            // return _context.CustomerAccounts;
            var query = _context.CustomerAccounts
            .Include(acc => acc.AccountRates)
            .Include(acc => acc.CreatedBy)
            .Include(acc => acc.UpdatedBy)
            .Include(acc => acc.InstructorAccounts)
            .Select(acc => new
            {
                customerAccountId = acc.CustomerAccountId,
                accountName       = acc.AccountName,
                numAccountRates   = acc.AccountRates.Count,
                numInstructors    = acc.InstructorAccounts.Count,
                comments          = acc.Comments,
                updatedBy         = acc.UpdatedBy.FullName,
                updatedAt         = acc.UpdatedAt,
                isVisible         = acc.IsVisible
            });
            return Json(query);
        }

        // GET: api/CustomerAccounts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerAccount([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customerAccount = await _context.CustomerAccounts
                .SingleOrDefaultAsync(m => m.CustomerAccountId == id);

            if (customerAccount == null)
            {
                return NotFound();
            }

            return Ok(customerAccount);
        }

        // PUT: api/CustomerAccounts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerAccount([FromRoute] int id, [FromBody] CustomerAccount customerAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerAccount.CustomerAccountId)
            {
                return BadRequest();
            }

            _context.Entry(customerAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerAccountExists(id))
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

        // POST: api/CustomerAccounts
        [HttpPost]
        public async Task<IActionResult> PostCustomerAccount([FromBody] CustomerAccountViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customerAccount = new CustomerAccount
            {
                AccountName = vm.AccountName,
                Comments    = vm.Comments,
                IsVisible   = vm.IsVisible,
                CreatedAt   = vm.CreatedAt,
                CreatedById = vm.CreatedById,
                UpdatedById = vm.UpdatedById,
                UpdatedAt   = vm.UpdatedAt,
            };

            // TODO: Make this a transaction
            _context.CustomerAccounts.Add(customerAccount);
            await _context.SaveChangesAsync();

            var accountRate = new AccountRate
            {
                CustomerAccountId  = customerAccount.CustomerAccountId,
                RatePerHour        = vm.RatePerHour,
                EffectiveStartDate = vm.EffectiveStartDate,
                EffectiveEndDate   = vm.EffectiveEndDate,
            };

            _context.AccountRates.Add(accountRate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerAccount", new { accId = customerAccount.CustomerAccountId, rateId = accountRate.AccountRateId }, customerAccount);
        }

        // DELETE: api/CustomerAccounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerAccount([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customerAccount = await _context.CustomerAccounts.SingleOrDefaultAsync(m => m.CustomerAccountId == id);
            if (customerAccount == null)
            {
                return NotFound();
            }

            _context.CustomerAccounts.Remove(customerAccount);
            await _context.SaveChangesAsync();

            return Ok(customerAccount);
        }

        private bool CustomerAccountExists(int id)
        {
            return _context.CustomerAccounts.Any(e => e.CustomerAccountId == id);
        }
    }
}