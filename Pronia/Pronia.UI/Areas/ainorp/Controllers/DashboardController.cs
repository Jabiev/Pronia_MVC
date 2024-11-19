using Microsoft.AspNetCore.Mvc;

namespace Pronia.UI.Areas.ainorp.Controllers;

[Area(nameof(ainorp))]
public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
