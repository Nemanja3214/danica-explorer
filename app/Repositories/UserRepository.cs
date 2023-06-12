using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Model;
using app.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace app.Repositories;

public class UserRepository : IUserRepository
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
    
    public async Task<User> GetById(int id)
    {
        return _context.Users.Find(id);
    }

    public Task<User> GetByEmail(string email)
    {
        return _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public User Create(User user)
    {
        User newUser = _context.Users.Add(user).Entity;
        _context.SaveChanges();
        return newUser;
    }
}