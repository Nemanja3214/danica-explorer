using app.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace app.Repositories;

public class ServiceRepository
{
    public DanicaExplorerContext _context;

    public ServiceRepository(DanicaExplorerContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Service>> GetAll()
    {
        return await _context.Services.ToListAsync();
    }
}