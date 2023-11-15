using IdeaBunker.Data;
using IdeaBunker.Models;
using Microsoft.AspNetCore.Identity;

namespace IdeaBunker.Services;

public partial class DataService : IDataService
{
    private readonly Context _context;
    private readonly UserManager<User> _userManager;

    public DataService(Context context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }
}