using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pronia.Data.Contexts;
using Pronia.Domain.Entities;
using Pronia.UI.ViewModels;

namespace Pronia.UI.Controllers;

public class AccountController(SignInManager<User> signInManager,
        UserManager<User> userManager,
        ProniaDbContext context) : Controller
{
    private readonly SignInManager<User> _signInManager = signInManager;
    private readonly ProniaDbContext _context = context;
    private readonly UserManager<User> _userManager = userManager;

    public IActionResult Register() => View();
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            User user = new User()
            {
                FirstName = model.Name,
                Email = model.Email,
                UserName = model.Email,
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
                return View(model);
            }
            return RedirectToAction(nameof(Login));
        }
        return View(model);
    }
    public IActionResult Login() => View();
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            if ((await _userManager.FindByEmailAsync(model.Email)) is null)
            {
                ModelState.AddModelError("", "Not Found");
                return View(model);
            }
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if (result.Succeeded)
                return RedirectToAction("Index", "Home");
            else
            {
                ModelState.AddModelError("", "Email or Password is incorrect");
                return View(model);
            }
        }
        return View(model);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}
