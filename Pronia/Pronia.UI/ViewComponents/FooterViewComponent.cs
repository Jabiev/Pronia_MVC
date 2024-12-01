using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia.Data.Contexts;
using Pronia.Domain.Entities;

namespace Pronia.UI.ViewComponents;

public class FooterViewComponent(ProniaDbContext context) : ViewComponent
{
    private readonly ProniaDbContext _context = context;

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var datas = await _context.Biography.ToDictionaryAsync(b => b.Key, b => new Biography()
        {
            Icon = b.Icon,
            Value = b.Value
        });
        return View(datas);
    }
}
