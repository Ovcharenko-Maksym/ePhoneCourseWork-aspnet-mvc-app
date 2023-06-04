using ePhoneCourseWork.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ePhoneCourseWork.Controllers
{
    public class ApplicationUserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        [HttpPost]
        public IActionResult BlacklistUser(string userId)
        {
            var userTask =  _userManager.FindByIdAsync(userId);

            userTask.Wait();

            var user = userTask.Result;
            if (user != null)
            {
                user.IsBlacklisted = true;
                _userManager.UpdateAsync(user);
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> RemoveFromBlacklist(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                user.IsBlacklisted = false;
                await _userManager.UpdateAsync(user);
            }
            return RedirectToAction("Users");
        }
    }
}
