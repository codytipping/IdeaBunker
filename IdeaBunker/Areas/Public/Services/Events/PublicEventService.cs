using IdeaBunker.Data;

namespace IdeaBunker.Areas.Public.Services;

public partial interface IPublicEventService { }
public partial class PublicEventService : IPublicEventService
{ 
    private readonly Context _context;

    public PublicEventService(Context context)
    {
        _context = context;
    }
}