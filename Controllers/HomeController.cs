using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreVue.Data;
using NetCoreVue.Models;

namespace NetCoreVue.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        public HomeController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var (userId, fullName) = await GetUserIdFromUserInfoAsync();
            ViewData["UserId"] = userId;
            ViewData["FullName"] = fullName;
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region Helpers

        public async Task<(int, string)> GetUserIdFromUserInfoAsync()
        {
            var loginId = _userManager.GetUserName(User);
            var userId = await _context.UserInfo
                .SingleOrDefaultAsync(u => u.LoginUserName == loginId);
            return (userId.UserInfoId, userId.FullName);
        }

        #endregion
    }
}
