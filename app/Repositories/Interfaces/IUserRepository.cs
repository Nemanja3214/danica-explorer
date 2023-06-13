using System.Collections.Generic;
using System.Threading.Tasks;
using app.Model;

namespace app.Repositories.Interfaces;

public interface IUserRepository
{
    public Task<IEnumerable<User>> GetAll();

    public Task<User> GetById(int id);

    public Task<User> GetByEmail(string email);

    public User Create(User user);

    public Task<IEnumerable<Reservation>> GetAllReservations(User user);
}