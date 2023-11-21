using IdeaBunker.Areas.Identity.Models;
using IdeaBunker.Data;
using IdeaBunker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdeaBunker.Areas.Public.Controllers;

[Area("Public")]
public partial class CategoryDraftController : Controller
{
    private readonly Context _context;
    private readonly UserManager<User> _userManager;

    public CategoryDraftController(Context context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }
}