using app.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace app.Repositories;

public class AttractionRepository
{
    public DanicaExplorerContext _context;

    public AttractionRepository(DanicaExplorerContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Attraction>> GetAll()
    {
        return await _context.Attractions
            .Include(x => x.Location)
            .ToListAsync();
    }
}