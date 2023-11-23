using IdeaBunker.Data;
using IdeaBunker.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IdeaBunker.Controllers;

[Authorize]
public partial class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly Context _context;

    public HomeController(ILogger<HomeController> logger, Context context)
    {
        _logger = logger;
        _context = context; 
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}