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
        var sliders = await _context.Sliders.ToListAsync();
        return View(sliders);
    }
    public async Task<IActionResult> Detail(int id)
    {
        var slider = await _context.Sliders.FindAsync(id);
        if (slider is null)
            return NotFound();
        return View(slider);
    }
    //public async Task<IActionResult> Create()
    //{
    //    var slider = await _context.Sliders.FindAsync(id);
    //    if (slider is null)
    //        return NotFound();
    //    return View(slider);
    //}
    //public async Task<IActionResult> Remove(int id)
    //{
    //    var slider = await _context.Sliders.FindAsync(id);
    //    if (slider is null)
    //        return NotFound();
    //    _context.Sliders.Remove(slider);
    //    await _context.SaveChangesAsync();
    //    return View(slider);
    //}
}
