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
            return View();
        }

        // POST: /Account/AdminLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminLogin(AdminLoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Attempt to sign in the user with the provided email and password
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                // If login is successful, redirect to the AdminPanel action in the HomeController
                return RedirectToAction(nameof(HomeController.AdminPanel), "Home");
            }
            else
            {
                // If login fails, add a model error and return to the view with the validation message
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }
        }

    }
}

