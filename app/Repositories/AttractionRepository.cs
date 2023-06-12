using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using app.Model;
using app.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;

public class AttractionRepository : IAttractionRepository
{
    private readonly DanicaExplorerContext _context;

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

    public async Task<Attraction?> GetById(int id)
    {
        return await _context.Attractions
            .Include(x => x.Location)
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();
    }

    public Attraction Create(Attraction attraction)
    {
        Attraction newAttraction = _context.Attractions.Add(attraction).Entity;
         _context.SaveChanges();
        return newAttraction;
    }

    public Attraction Update(Attraction attraction)
    {
        EntityEntry<Attraction> res = _context.Attractions.Attach(attraction);
        _context.SaveChanges();
        return res.Entity;
    }

    public Attraction Delete(Attraction attraction)
    {
        attraction.Isdeleted = true;
        return Update(attraction);
    }
}