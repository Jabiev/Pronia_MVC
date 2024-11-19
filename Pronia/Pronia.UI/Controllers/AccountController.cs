using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pronia.Domain.Entities;
using Pronia.UI.ViewModels;

namespace Pronia.UI.Controllers;

public class AccountController : Controller
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;

    public AccountController(SignInManager<User> signInManager,
        UserManager<User> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public IActionResult Login() => View();
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
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

    public IActionResult Register() => View();
    [HttpPost]
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
            if (result.Succeeded)
                return RedirectToAction("Login", "Account");//as soon as
            else
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
                return View(model);
            }
        }
        return View(model);
    }
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}
