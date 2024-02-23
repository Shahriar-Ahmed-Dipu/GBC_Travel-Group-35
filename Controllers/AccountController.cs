using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using GBC_Travel_Group_35.Models;
using System.Threading.Tasks;

namespace GBC_Travel_Group_35.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager; // Include if you need user management functionality

        // Dependency injection to get SignInManager and UserManager
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: /Account/AdminLogin
        public IActionResult AdminLogin()
        {
            return View(new AdminLoginViewModel());
        }

        // POST: /Account/AdminLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminLogin(AdminLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    // Redirect the admin to the dashboard or another appropriate area of the site
                    return RedirectToAction("Index", "Dashboard");
                }
                ModelState.AddModelError("", "Invalid login attempt.");
            }
            return View(model);
        }
    }
}
