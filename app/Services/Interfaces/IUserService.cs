using System.Collections.Generic;
using System.Threading.Tasks;
using app.Model;

namespace app.Services.Interfaces;

public interface IUserService
{
    public  Task<User> GetById(int id);
    public Task<User> Login(string email, string password);

    public Task<User> Register(User user);

    public Task<IEnumerable<Reservation>> GetAllReservations(User user);
}