using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreVue.Data;
using NetCoreVue.Models;

namespace NetCoreVue.Controllers
{
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
        public IEnumerable<CustomerAccount> GetCustomerAccounts()
        {
            return _context.CustomerAccounts;
        }

        // GET: api/CustomerAccounts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerAccount([FromRoute] int id)
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
        public async Task<IActionResult> PostCustomerAccount([FromBody] CustomerAccount customerAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CustomerAccounts.Add(customerAccount);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerAccount", new { id = customerAccount.CustomerAccountId }, customerAccount);
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