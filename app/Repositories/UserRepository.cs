using System.Collections.Generic;
using System.Threading.Tasks;
using app.Model;
using Microsoft.EntityFrameworkCore;

namespace app.Repositories;

public class UserRepository
{

    public DanicaExplorerContext _context;

    public UserRepository(DanicaExplorerContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _context.Users.ToListAsync();
    }
}