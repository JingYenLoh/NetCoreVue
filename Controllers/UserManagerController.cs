using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetCoreVue.Data;
using NetCoreVue.Models;
using NetCoreVue.Models.UserViewModels;

namespace NetCoreVue.Controllers
{
    [Authorize(Roles = "Admin")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserManagerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserManagerController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/UserManager
        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            #region Screw this stuff
            // Returns BadRequest, api borked
            // var users = _userManager.Users
            //     .Select(user => new
            //     {
            //         id = user.Id,
            //         userName = user.UserName,
            //         email = user.Email,
            //         fullName = user.FullName,
            //         emailConfirmed = user.EmailConfirmed,
            //         role = _userManager.GetRolesAsync(user)
            //     });

            // List<UserViewModel> results = users
            //     .Select(async user =>
            //     {
            //         var roleName = await _userManager.GetRolesAsync(user);
            //         return await new UserViewModel()
            //         {
            //             Id = user.Id,
            //             UserName = user.UserName,
            //             Email = user.Email,
            //             FullName = user.FullName,
            //             EmailConfirmed = user.EmailConfirmed,
            //             RoleName = roleName[0]
            //         };
            //     }).ToListAsync();

            // Raw SQL
            // Doesn't work, insists on ApplicationUser model
            // var users = _userManager.Users
            //     .FromSql($@"
            //         SELECT
            //         u.Id,
            //         u.UserName,
            //         u.Email,
            //         u.FullName,
            //         u.EmailConfirmed,
            //         r.Name 
            //         FROM AspNetUserRoles AS ur
            //         JOIN AspNetUsers AS u ON ur.UserId = u.Id
            //         JOIN AspNetRoles AS r ON ur.RoleId = r.Id")
            //     .ToList();
            #endregion

            var users = _userManager.Users.ToArray();

            if (users.Length == 0)
            {
                return NotFound();
            }

            var results = new List<UserViewModel>();

            foreach (var user in users)
            {
                var roleName = await _userManager.GetRolesAsync(user);
                results.Add(new UserViewModel
                {
                    Id             = user.Id,
                    UserName       = user.UserName,
                    Email          = user.Email,
                    FullName       = user.FullName,
                    EmailConfirmed = user.EmailConfirmed,
                    RoleName       = roleName[0] // Only need to retrieve first
                });
            }

            return Json(results);
        }

        // GET: api/UserManager/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var roles = await _userManager.GetRolesAsync(user);
            return Ok(new { user, roles });
        }

        // PUT: api/UserManager/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] string id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // POST: api/UserManager
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/UserManager/5
        [HttpDelete("{id}")]
        public IAsyncResult Delete([FromRoute] string id)
        {
            throw new NotImplementedException();
        }

        // TODO: Write APIs for updating user roles
        
    }
}