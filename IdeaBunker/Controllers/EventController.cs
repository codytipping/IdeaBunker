using IdeaBunker.Areas.Identity.Models;
using IdeaBunker.Areas.Public.ViewModels;
using IdeaBunker.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IdeaBunker.Controllers;

public class EventController : Controller
{
    private readonly Context _context;
    private readonly UserManager<User> _userManager;

    public EventController(Context context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }
}