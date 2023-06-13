using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Model;
using app.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace app.Repositories;

public class LocationRepository : ILocationRepository
{
    public DanicaExplorerContext _context;

    public LocationRepository(DanicaExplorerContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Location>> GetAll()
    {
        return await _context.Locations.ToListAsync();
    }
    
    public async Task<Location> GetById(int id)
    {
        return await _context.Locations.FindAsync(id);
    }

    public Location Create(Location location)
    {
        Location newLocation = _context.Locations.Add(location).Entity;
        _context.SaveChanges();
        return newLocation;
    }

}