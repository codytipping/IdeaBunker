using IdeaBunker.Data;

namespace IdeaBunker.Services;

public partial class EventService : IEventService
{
    private readonly Context _context;

    public EventService(Context context) { _context = context; }
}