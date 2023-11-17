using IdeaBunker.Data;

namespace IdeaBunker.Areas.Identity.Services;

public partial interface IIdentityEventService { }

public partial class IdentityEventService : IIdentityEventService
{
    private readonly Context _context;

    public IdentityEventService(Context context)
    {
        _context = context;
    }
}