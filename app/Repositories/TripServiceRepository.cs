using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Model;
using app.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace app.Repositories;

public class TripServiceRepository : ITripServiceRepository
{
    public DanicaExplorerContext _context;

    public TripServiceRepository(DanicaExplorerContext context)
    {
        _context = context;
    }

    public async Task<TripService?> GetById(int id)
    {
        return await _context.TripServices.Where(x => x.Id == id)
            .Include(x => x.Trip)
            .Include(x => x.Service)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<TripService>> GetAllForTrip(Trip trip)
    {
        return await _context.TripServices
            .Include(x => x.Trip)
            .Include(x => x.Service)
            .Where(x => x.TripId == trip.Id)
            .ToListAsync();
    }

    public async Task<IEnumerable<TripService>> GetAllForService(Service service)
    {
        return await _context.TripServices
            .Include(x => x.Trip)
            .Include(x => x.Service)
            .Where(x => x.ServiceId == service.Id)
            .ToListAsync();
    }

    public async Task<IEnumerable<TripService>> GetAll()
    {
        return await _context.TripServices
            .Include(x => x.Trip)
            .Include(x => x.Service)
            .ToListAsync();
    }

    public TripService Create(TripService tripService)
    {
        EntityEntry<TripService> res = _context.TripServices.Add(tripService);
        _context.SaveChanges();
        return res.Entity;
    }

    public TripService Update(TripService tripService)
    {
        EntityEntry<TripService> res = _context.TripServices.Attach(tripService);
        _context.SaveChanges();
        return res.Entity;
    }

    public TripService Delete(TripService tripService)
    {
        tripService.Isdeleted = true;
        return Update(tripService);
    }
}