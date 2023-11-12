using IdeaBunker.Areas.Identity.Models.Entities;
using IdeaBunker.Areas.Public.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdeaBunker.Areas.Public.Controllers.Projects;

public class ProjectsController : Controller
{
    private readonly PublicContext _context;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;       

    public ProjectsController(PublicContext context, UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _context = context;
        _signInManager = signInManager;
    }

}