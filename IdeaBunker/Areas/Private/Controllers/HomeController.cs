using Microsoft.AspNetCore.Mvc;

namespace IdeaBunker.Areas.Private.Controllers;

[Area("Private")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
