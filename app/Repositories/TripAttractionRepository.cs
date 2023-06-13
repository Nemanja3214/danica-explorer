using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Model;
using app.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace app.Repositories;

public class TripAttractionRepository : ITripAttractionRepository
{
        
    public DanicaExplorerContext _context;

    public TripAttractionRepository(DanicaExplorerContext context)
    {
        _context = context;
    }

    public async Task<TripAttraction?> GetById(int id)
    {
        return await _context.TripAttractions.Where(x => x.Id == id)
            .Include(x => x.Trip)
            .Include(x => x.Attraction)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<TripAttraction>> GetAllForAttractions(Attraction attraction)
    {
        return await _context.TripAttractions
            .Include(x => x.Trip)
            .Include(x => x.Attraction)
            .Where(x=> x.AttractionId == attraction.Id)
            .ToListAsync();
    }

    public async Task<IEnumerable<TripAttraction>> GetAllForTrip(Trip trip)
    {
        return await _context.TripAttractions
            .Include(x => x.Trip)
            .Include(x => x.Attraction)
            .Where(x => x.TripId == trip.Id)
            .ToListAsync();
    }


    public async Task<IEnumerable<TripAttraction>> GetAll()
    {
        return await _context.TripAttractions
            .Include(x => x.Trip)
            .Include(x => x.Attraction)
            .ToListAsync();
    }

    public TripAttraction Create(TripAttraction tripAttraction)
    {
        EntityEntry<TripAttraction> res = _context.TripAttractions.Add(tripAttraction);
        _context.SaveChanges();
        return res.Entity;
    }

    public TripAttraction Update(TripAttraction tripAttraction)
    {
        EntityEntry<TripAttraction> res = _context.TripAttractions.Attach(tripAttraction);
        _context.SaveChanges();
        return res.Entity;
    }

    public TripAttraction Delete(TripAttraction tripAttraction)
    {
        tripAttraction.Isdeleted = true;
        return Update(tripAttraction);
    }
}