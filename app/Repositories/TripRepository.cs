using app.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace app.Repositories;

public class TripRepository
{
    public DanicaExplorerContext _context;

    public TripRepository(DanicaExplorerContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Trip>> GetAll()
    {
        return await _context.Trips
            .Include(x => x.TripAttractions)
            .Include(x => x.TripAttractions)
            .ToListAsync();
    }
}