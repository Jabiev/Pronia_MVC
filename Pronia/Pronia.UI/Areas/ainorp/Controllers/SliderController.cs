using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia.Data.Contexts;
using Pronia.Domain.Entities;
using Pronia.UI.Areas.ainorp.ViewModels;

namespace Pronia.UI.Areas.ainorp.Controllers;

[Area(nameof(ainorp))]
public class SliderController : Controller
{
    private readonly ProniaDbContext _context;
    private readonly IWebHostEnvironment _env;

    public SliderController(ProniaDbContext context, IWebHostEnvironment env)
    {
        _context = context;
        _env = env;
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
    public async Task<IActionResult> Create(SliderViewModel sliderVM)
    {
        var sliderCount = await _context.Sliders.CountAsync();

        if (sliderCount >= 5)
        {
            ModelState.AddModelError("limit", "Don't EXCEED Slider limit! You may create a slider max 5");
            return View(sliderVM);
        }

        if (!ModelState.IsValid)
            return View();

        if (!sliderVM.Image.CheckFileType("image/"))
        {
            ModelState.AddModelError("Image", "Please choose the image file which is indeed image");
            return View(sliderVM);
        }

        if (!sliderVM.Image.CheckFileSizeKb(100))
        {
            ModelState.AddModelError("Image", "Please choose the image file which not exceeding file size");
            return View(sliderVM);
        }

        var dbPath = sliderVM.Image.CreateFile(_env.WebRootPath, "front", "assets", "images", "slider", "slide-img");

        Slider slider = new()
        {
            ImageUrl = dbPath,
            Title = sliderVM.Title,
            Description = sliderVM.Description,
            Offer = sliderVM.Offer
        };

        await _context.Sliders.AddAsync(slider);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Remove(int id)
    {
        var slider = await _context.Sliders.FindAsync(id);
        if (slider is null)
            return NotFound();

        string filePath = _env.WebRootPath + slider.ImageUrl;

        if (System.IO.File.Exists(filePath))
            System.IO.File.Delete(filePath);

        _context.Sliders.Remove(slider);
        await _context.SaveChangesAsync();
        return View(slider);
    }
    public async Task<IActionResult> Update(int id)
    {
        var slider = await _context.Sliders.FindAsync(id);
        if (slider is null)
            return NotFound();
        SliderCommon common = new()
        {
            Slider = slider
        };
        return View(common);
    }
    [HttpPost]
    public async Task<IActionResult> Update(int id, SliderCommon common)
    {
        var existSlider = await _context.Sliders.FindAsync(id);
        if (existSlider is null)
            return NotFound();

        if (common.SliderModel.Image is not null)
        {
            if (!common.SliderModel.Image.CheckFileType("image/"))
            {
                ModelState.AddModelError("Image", "Please choose the image file which is indeed image");
                return View(common.SliderModel);
            }

            if (!common.SliderModel.Image.CheckFileSizeKb(100))
            {
                ModelState.AddModelError("Image", "Please choose the image file which not exceeding file size");
                return View(common.SliderModel);
            }
            string filePath = _env.WebRootPath + existSlider.ImageUrl;
            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);
            var dbPath = common.SliderModel.Image.CreateFile(_env.WebRootPath, "front", "assets", "images", "slider", "slide-img");
            existSlider.ImageUrl = dbPath;
        }

        if (common.SliderModel.Title is not null)
            existSlider.Title = common.SliderModel.Title;
        if (common.SliderModel.Description is not null)
            existSlider.Description = common.SliderModel.Description;
        if (common.SliderModel.Offer is not null)
            existSlider.Offer = common.SliderModel.Offer;
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
