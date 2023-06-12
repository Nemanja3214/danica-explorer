using app.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace app.Repositories;

public class ReservationRepository
{
    public DanicaExplorerContext _context;

    public ReservationRepository(DanicaExplorerContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Reservation>> GetAll()
    {
        return await _context.Reservations
            .Include(x => x.Trip)
            .Include(x => x.User)
            .Include(x => x.Trip.TripServices)
            .Include(x => x.Trip.TripAttractions)
            .ToListAsync();
    }
}