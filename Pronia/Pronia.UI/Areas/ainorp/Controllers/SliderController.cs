using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia.Data.Contexts;
using Pronia.Domain.Entities;

namespace Pronia.UI.Areas.ainorp.Controllers;

[Area(nameof(ainorp))]
public class SliderController : Controller
{
    private readonly ProniaDbContext _context;

    public SliderController(ProniaDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var sliders = await _context.Sliders.AsNoTracking().ToListAsync();
        return View(sliders);
    }
    public async Task<IActionResult> Detail(int id)
    {
        var slider = await _context.Sliders.FindAsync(id);
        if (slider is null)
            return NotFound();
        return View(slider);
    }
    public async Task<IActionResult> Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(Slider slider)
    {
        var sliderCount = await _context.Sliders.CountAsync();

        if (sliderCount >= 5)
        {
            ModelState.AddModelError(string.Empty, "Don't EXCEED Slider limit! You may create a slider max 5");
            return View(slider);
        }

        if (!ModelState.IsValid) 
            return View();
        await _context.Sliders.AddAsync(slider);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Remove(int id)
    {
        var slider = await _context.Sliders.FindAsync(id);
        if (slider is null)
            return NotFound();
        _context.Sliders.Remove(slider);
        await _context.SaveChangesAsync();
        return View(slider);
    }
    public async Task<IActionResult> Update(int id)
    {
        var slider = await _context.Sliders.FindAsync(id);
        if (slider is null)
            return NotFound();
        return View(slider);
    }
    [HttpPost]
    public async Task<IActionResult> Update(int id, Slider slider)
    {
        var existSlider = await _context.Sliders.FindAsync(id);
        if (existSlider is null)
            return NotFound();
        existSlider.Title = slider.Title;
        existSlider.Description = slider.Description;
        existSlider.Offer = slider.Offer;
        existSlider.ImageUrl = slider.ImageUrl;
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
