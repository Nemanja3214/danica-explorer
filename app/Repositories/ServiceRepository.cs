using app.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace app.Repositories;

public class ServiceRepository : IServiceRepository
{
    public DanicaExplorerContext _context;

    public ServiceRepository(DanicaExplorerContext context)
    {
        _context = context;
    }

    public async Task<Service?> GetById(int id)
    {
        return await _context.Services.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Service>> GetAll()
    {
        return await _context.Services.ToListAsync();
    }

    public Service Create(Service service)
    {
        EntityEntry<Service> res = _context.Services.Add(service);
        _context.SaveChanges();
        return res.Entity;
    }

    public Service Update(Service service)
    {
        EntityEntry<Service> res = _context.Services.Attach(service);
        _context.SaveChanges();
        return res.Entity;
    }

    public Service Delete(Service service)
    {
        service.Isdeleted = true;
        return Update(service);
    }
    
    public async Task<IEnumerable<Service>> Search(string input, bool isHotel)
    {
        return await _context.Services.Include(s => s.Location).Where(entity => entity.Title.Contains(input) && entity.Ishotel.Equals(isHotel)).ToListAsync();
    }
}