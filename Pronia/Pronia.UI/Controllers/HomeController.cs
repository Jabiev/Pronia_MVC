using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia.Data.Contexts;
using Pronia.UI.ViewModels;

namespace Pronia.UI.Controllers;

public class HomeController : Controller
{
    private readonly ProniaDbContext _proniaDbContext;

    public HomeController(ProniaDbContext proniaDbContext)
    {
        _proniaDbContext = proniaDbContext;
    }

    public async Task<IActionResult> Index()
    {
        HomeViewModel homeViewModel = new()
        {
            Products = await _proniaDbContext.Products.ToListAsync(),
            Sliders = await _proniaDbContext.Sliders.ToListAsync(),
            Testimonials = await _proniaDbContext.Testimonials.ToListAsync()
        };
        return View(homeViewModel);
    }
}
